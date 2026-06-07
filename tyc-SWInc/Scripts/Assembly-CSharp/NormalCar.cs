using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;

public class NormalCar : MonoBehaviour
{
	[ContextMenuItem("From clipboard", "FromClipboard")]
	[ContextMenuItem("From material", "FromMaterial")]
	public Color[] Colors;

	public List<Vector3> Path;

	public bool GoHome;

	public bool Debug;

	public bool Sync = true;

	private float TrafficWait = -1f;

	private float UltimateWait = -1f;

	public int DeltaTest = 1;

	private int DeltaCountdown;

	private Color DeColor;

	private int currentNode;

	private RoadNode Goal;

	public CarScript Car;

	public Color MyColor;

	private PathNode<Vector3> _last;

	[NonSerialized]
	private Dictionary<RoadSegment, int> _visited = new Dictionary<RoadSegment, int>();

	public bool IsAI;

	private Utilities.Direction _direction;

	private Utilities.Direction _preferredDirections;

	private bool _pathFinished;

	private static Utilities.Direction[] _directionChoice = new Utilities.Direction[4];

	public void FromClipboard()
	{
		List<Color> list = new List<Color>();
		string[] array = GUIUtility.systemCopyBuffer.Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array)
		{
			Color color;
			if (ColorUtility.TryParseHtmlString("#" + text.Replace("#", ""), out color))
			{
				list.Add(color);
			}
		}
		Colors = list.ToArray();
	}

	public void FromMaterial()
	{
		List<Color> list = Colors.ToList();
		list.Add(Car.CarRender[0].sharedMaterial.color);
		string[] array = GUIUtility.systemCopyBuffer.Split(new string[2] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array)
		{
			Color color;
			if (ColorUtility.TryParseHtmlString("#" + text.Replace("#", ""), out color))
			{
				list.Add(color);
			}
		}
		Colors = list.ToArray();
	}

	public void Reset()
	{
		GoHome = false;
		Debug = false;
		TrafficWait = -1f;
		UltimateWait = -1f;
		currentNode = 0;
		Goal = null;
		Path = null;
		IsAI = false;
		_last = null;
		_pathFinished = false;
		_visited.Clear();
	}

	public RoadNode GetGoal()
	{
		return Goal;
	}

	public void DummyGoal(RoadNode n)
	{
		Goal = n;
		Path = new List<Vector3>();
	}

	public void DestroyEvent()
	{
		if (Goal != null && !GoHome)
		{
			Goal.Taken = false;
		}
	}

	private void InitAI()
	{
		Path = new List<Vector3>();
		RoadNode randomInput = RoadManager.Instance.GetRandomInput();
		_last = randomInput.self;
		Utilities.Direction direction = new Vector2Int((randomInput.Parent.x == 0) ? 1 : (-1), 0).ToDirection();
		Utilities.Direction direction2 = new Vector2Int(0, (randomInput.Parent.y == 0) ? 1 : (-1)).ToDirection();
		_direction = ((UnityEngine.Random.value > 0.5f) ? direction : direction2);
		_preferredDirections = direction | direction2;
		PlanStepsAhead(4);
		if (Path.Count > 0)
		{
			Vector2Int vector2Int = _direction.ToVector();
			Path[0] = Path[0] - new Vector3((float)vector2Int.x * 2.5f, 0f, (float)vector2Int.y * 2.5f);
		}
		else
		{
			_pathFinished = true;
			Path = null;
		}
	}

	private bool PlanStepsAhead(int steps)
	{
		if (_pathFinished)
		{
			return true;
		}
		CleanPath();
		for (int i = 0; i < steps; i++)
		{
			if (!PlanAhead())
			{
				return _pathFinished;
			}
		}
		return true;
	}

	private void CleanPath()
	{
		if (currentNode > 0)
		{
			for (int i = 0; i < currentNode; i++)
			{
				Path.RemoveAt(0);
			}
			currentNode = 0;
		}
	}

	private bool PlanAhead()
	{
		if (_pathFinished)
		{
			return false;
		}
		int num = 0;
		int num2 = 2;
		_directionChoice[3] = _direction.ToOpposite();
		int num3 = UnityEngine.Random.Range(0, 4);
		for (int i = 0; i < 4; i++)
		{
			int num4 = (i + num3) % 4;
			Utilities.Direction direction = (Utilities.Direction)(1 << num4);
			if (!direction.IsOpposite(_direction))
			{
				if ((direction & _preferredDirections) != Utilities.Direction.None)
				{
					_directionChoice[num] = direction;
					num++;
				}
				else
				{
					_directionChoice[num2] = direction;
					num2--;
				}
			}
		}
		RoadNode roadNode = _last.Tag as RoadNode;
		if (roadNode == null)
		{
			return false;
		}
		int num5 = int.MaxValue;
		RoadSegment roadSegment = null;
		Utilities.Direction direction2 = Utilities.Direction.None;
		for (int j = 0; j < _directionChoice.Length; j++)
		{
			Utilities.Direction direction3 = _directionChoice[j];
			if (direction3 == Utilities.Direction.None)
			{
				continue;
			}
			Vector2Int vector2Int = direction3.ToVector();
			RoadSegment segment = RoadManager.Instance.GetSegment(roadNode.Parent.x + vector2Int.x, roadNode.Parent.y + vector2Int.y, roadNode.Parent.GetFloorTo(direction3));
			if (!(segment != null) || !segment.AIAllowed)
			{
				continue;
			}
			int value;
			if (!_visited.TryGetValue(segment, out value) && segment.Parking.Length == 0)
			{
				PathNode<Vector3> pathNode = roadNode.PathTo(segment, _last, Path);
				if (pathNode != null)
				{
					_visited.AddUp(segment);
					_last = pathNode;
					_direction = direction3;
					if ((pathNode.Tag as RoadNode).Parent.IsInputOutput)
					{
						_pathFinished = true;
						Path.Add(Path.Last() + new Vector3((float)vector2Int.x * 10f, 0f, (float)vector2Int.y * 10f));
					}
					return true;
				}
			}
			else
			{
				if (direction3.IsOpposite(_direction))
				{
					value = Mathf.Max(1, value) * 4;
				}
				if (value < num5)
				{
					num5 = value;
					roadSegment = segment;
					direction2 = direction3;
				}
			}
		}
		if (roadSegment != null)
		{
			PathNode<Vector3> pathNode2 = roadNode.PathTo(roadSegment, _last, Path);
			if (pathNode2 != null)
			{
				_visited.AddUp(roadSegment);
				_last = pathNode2;
				_direction = direction2;
				if ((pathNode2.Tag as RoadNode).Parent.IsInputOutput)
				{
					Vector2Int vector2Int2 = direction2.ToVector();
					_pathFinished = true;
					Path.Add(Path.Last() + new Vector3((float)vector2Int2.x * 10f, 0f, (float)vector2Int2.y * 10f));
				}
				return true;
			}
		}
		return false;
	}

	public void Init()
	{
		if (Car.Ghost)
		{
			return;
		}
		Car.CurrentSpeed = Car.Speed;
		Goal = Car.Target;
		if (IsAI)
		{
			InitAI();
			if (Path == null)
			{
				RoadManager.Instance.DestroyCar(Car);
				return;
			}
		}
		else
		{
			if (Debug)
			{
				Goal = RoadManager.Instance.FindRandomParking();
				if (Goal == null)
				{
					RoadManager.Instance.DestroyCar(Car);
					return;
				}
			}
			Path = RoadManager.Instance.MakeRoadPlan(ref Goal);
			if (Path == null || Goal == null)
			{
				if (Car.FireFighter)
				{
					if (Car.AnyOccupants())
					{
						Car.ForEachOccupant(delegate(Actor x)
						{
							x.DestroyGO();
						});
					}
				}
				else if (Car.AnyOccupants())
				{
					Car.ForEachOccupant(delegate(Actor x)
					{
						GameSettings.Instance.sActorManager.ReadyForBus.Add(x);
					});
				}
				if (Goal != null && Goal.Parking)
				{
					Goal.Taken = false;
				}
				RoadManager.Instance.DestroyCar(Car);
				return;
			}
			if (Goal.Parking)
			{
				Goal.Taken = true;
			}
			if (Car.AnyOccupants() || Car.FireFighter)
			{
				Car.CanDestroy = false;
			}
			if (Car.FireFighter)
			{
				Vector3 vector = Path.Last();
				float roadSize = RoadManager.Instance.RoadSize;
				float num = (float)Goal.Parent.x * roadSize + roadSize * 0.5f;
				float num2 = (float)Goal.Parent.y * roadSize + roadSize * 0.5f;
				float num3 = roadSize * 0.5f - 2f;
				Path[Path.Count - 1] = new Vector3(Mathf.Clamp(vector.x, num - num3, num + num3), vector.y, Mathf.Clamp(vector.z, num2 - num3, num2 + num3));
				RoadManager.FixPathEnds(Path, true, false);
			}
		}
		base.transform.SetPositionAndRotation(Path[0], Quaternion.LookRotation(Path[1] - Path[0]));
		Actor actor = Car.FirstActor();
		if (actor == null)
		{
			MyColor = Colors.GetRandom();
			Car.InitWheels();
		}
		else
		{
			MyColor = ((actor.IsEmployee() && !actor.employee.HasDemanded(LeadDesignDemands.Demand.LuxuryCar) && actor.GetBenefitValue("Company car") > 0f) ? GameSettings.Instance.CompanyCarColor : actor.CarColor3);
			Car.InitWheels(actor.CarWheelHubs);
		}
		Car.UpdateColor(MyColor);
	}

	public void ForceFinishRoute()
	{
		base.transform.position = Path[Path.Count - 1];
		base.transform.rotation = Quaternion.LookRotation(Path[Path.Count - 1] - Path[Path.Count - 2]);
		currentNode = Path.Count;
		Car.Parked = true;
		Car.CurrentSpeed = 0f;
		Car.LightsE = false;
		Car.AudioE = false;
	}

	public bool CheckTrafficCycle(List<IHasSpeed> Visit, List<IHasSpeed> Visited, CarScript caller)
	{
		for (int i = 0; i < Visit.Count; i++)
		{
			IHasSpeed hasSpeed = Visit[i];
			CarScript carScript = hasSpeed as CarScript;
			if (!(carScript != null))
			{
				continue;
			}
			if (Visited.Contains(hasSpeed))
			{
				for (int j = 0; j < carScript.WaitingFor.Count; j++)
				{
					CarScript carScript2 = carScript.WaitingFor[j] as CarScript;
					if (carScript2 != null && Mathf.Abs(Mathf.DeltaAngle(carScript2.transform.rotation.eulerAngles.y, carScript.transform.rotation.eulerAngles.y)) > 45f)
					{
						carScript.WaitingFor.Clear();
						return false;
					}
				}
				return true;
			}
			Visited.Add(hasSpeed);
			if (!CheckTrafficCycle(carScript.WaitingFor, Visited, carScript))
			{
				continue;
			}
			for (int k = 0; k < caller.WaitingFor.Count; k++)
			{
				CarScript carScript3 = caller.WaitingFor[k] as CarScript;
				if (carScript3 != null && Mathf.Abs(Mathf.DeltaAngle(carScript3.transform.rotation.eulerAngles.y, caller.transform.rotation.eulerAngles.y)) > 45f)
				{
					caller.WaitingFor.Clear();
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private void Update()
	{
		if (Car.Ghost || GameSettings.GameSpeed == 0f || Car.Delay > 0f)
		{
			return;
		}
		if (Path == null)
		{
			RoadManager.Instance.DestroyCar(Car);
			return;
		}
		float num = Time.deltaTime * GameSettings.GameSpeed;
		bool flag = false;
		if (Car.WaitingFor.Count > 0)
		{
			flag = true;
			float maxSpeed = Car.GetMaxSpeed(Car.GetAngle());
			Car.CurrentSpeed = (Car.Parked ? 0f : Mathf.Lerp(Car.CurrentSpeed, maxSpeed, num * ((Car.CurrentSpeed > maxSpeed) ? Car.Speed : (Car.Speed / 8f))));
			if (Car.CurrentSpeed <= 0f)
			{
				if (UltimateWait == -1f)
				{
					UltimateWait = 60f;
				}
				else
				{
					UltimateWait -= num;
					if (UltimateWait <= 0f)
					{
						Car.WaitingFor.Clear();
						UltimateWait = -1f;
					}
				}
				if (TrafficWait == -1f)
				{
					TrafficWait = UnityEngine.Random.Range(4, 6);
				}
				else
				{
					TrafficWait -= num;
					if (TrafficWait <= 0f)
					{
						CheckTrafficCycle(Car.WaitingFor, new List<IHasSpeed> { Car }, Car);
						TrafficWait = -1f;
					}
				}
			}
			else
			{
				UltimateWait = -1f;
				TrafficWait = -1f;
			}
		}
		else
		{
			TrafficWait = -1f;
		}
		if (currentNode >= Path.Count)
		{
			if (Goal == null)
			{
				RoadManager.Instance.DestroyCar(Car);
			}
			else if (GoHome || (Debug && Utilities.ChancePerInGameMinute(0.03f, Time.deltaTime) > 0))
			{
				if (Sync)
				{
					NetworkMessaging.SendClearGhostCar(Goal.Parent.x, Goal.Parent.y, Goal.Parent.floor, Goal.ID, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
				}
				Car.Parked = false;
				Goal.Taken = false;
				Car.CanDestroy = true;
				Path = RoadManager.Instance.GetHome(Goal);
				Goal = null;
				currentNode = 0;
				Car.LightsE = true;
				Car.AudioE = true;
				if (Path == null)
				{
					RoadManager.Instance.DestroyCar(Car);
				}
			}
			else if (!Car.FireFighter && !Debug && !Car.AnyLiveOccupants(true))
			{
				if (!Car.AllDoorsClosed())
				{
					for (int i = 0; i < Car.SpawnPoints.Length; i++)
					{
						Car.SpawnPoints[i].CloseDoor();
					}
				}
				else
				{
					GoHome = true;
				}
			}
			else if (!Car.IsSpawning() && Car.AnyDeadOccupants())
			{
				Car.BeginSpawn();
			}
			return;
		}
		Vector3 position = base.transform.position;
		float num2 = Car.CurrentSpeed * num;
		Vector3 vector = Path[currentNode] - position;
		float magnitude = vector.magnitude;
		Vector3 vector2 = vector;
		bool flag2 = vector2 == Vector3.zero;
		if (!flag2 && magnitude >= num2)
		{
			vector2 *= num2 / magnitude;
			flag2 = vector2 == Vector3.zero;
			num2 = 0f;
		}
		else
		{
			num2 -= magnitude;
		}
		if (Car.WaitingFor.Count == 0 && !flag)
		{
			Vector3 normalized = (GetPosAt(currentNode, magnitude + 2f) - base.transform.position).normalized;
			float num3 = (180f - Mathf.Abs(Vector3.Angle(base.transform.forward, normalized))) / 180f;
			num3 = Mathf.Max(0.2f, num3 * num3);
			if (Goal != null && Goal.Parking)
			{
				float num4 = 5f;
				if (currentNode < Path.Count - 2)
				{
					num4 = Car.Speed * num3;
				}
				float num5 = ((Car.CurrentSpeed < num4) ? (Car.Speed / 8f) : Car.Speed);
				Car.CurrentSpeed = Mathf.Lerp(Car.CurrentSpeed, num4, num * num5);
			}
			else
			{
				float num6 = num3 * Car.Speed;
				float num7 = ((Car.CurrentSpeed < num6) ? (Car.Speed / 8f) : Car.Speed);
				Car.CurrentSpeed = Mathf.Lerp(Car.CurrentSpeed, num6, num * num7);
			}
		}
		Vector3 position2 = base.transform.position + vector2;
		if (!flag2)
		{
			base.transform.SetPositionAndRotation(position2, Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(vector2), num * Car.CurrentSpeed));
		}
		else
		{
			base.transform.position = position2;
		}
		if (!(num2 > 0f))
		{
			return;
		}
		bool flag3 = num2 > 1f;
		int num8 = 0;
		float magnitude2 = (Path[currentNode] - base.transform.position).magnitude;
		bool flag4 = false;
		while (magnitude2 <= num2)
		{
			if (num8 > 25)
			{
				flag4 = false;
				break;
			}
			base.transform.position = Path[currentNode];
			currentNode++;
			if (IsAI && currentNode >= Path.Count - 3 && !PlanStepsAhead(4))
			{
				RoadManager.Instance.DestroyCar(Car);
			}
			if (currentNode == Path.Count)
			{
				if (IsAI)
				{
					RoadManager.Instance.DestroyCar(Car);
				}
				else if (Goal != null && (Goal.Parking || Car.FireFighter))
				{
					if (!Debug && !Car.AnyLiveOccupants() && !Car.FireFighter)
					{
						GoHome = true;
						return;
					}
					if (GameSettings.GameSpeed > 1f)
					{
						Vector3 normalized2 = (Path[currentNode - 1] - Path[currentNode - 2]).normalized;
						base.transform.rotation = Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(normalized2), UnityEngine.Random.Range(0.98f, 1f));
					}
					Car.BindOccupants();
					Car.BeginSpawn();
					Car.Parked = true;
					Car.CurrentSpeed = 0f;
					Car.LightsE = false;
					Car.AudioE = false;
					if (Sync)
					{
						int x = Goal.Parent.x;
						int y = Goal.Parent.y;
						int floor = Goal.Parent.floor;
						int iD = Goal.ID;
						int carIdx = Car.CarIdx;
						Vector3 position3 = base.transform.position;
						float y2 = base.transform.rotation.eulerAngles.y;
						Color color = Car.GetColor();
						Company logoCompany = Car.LogoCompany;
						NetworkMessaging.SendSetGhostCar(x, y, floor, iD, carIdx, position3, y2, color, (logoCompany != null) ? logoCompany.ID : 0u, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					}
				}
				else
				{
					RoadManager.Instance.DestroyCar(Car);
				}
				flag4 = false;
				break;
			}
			if (currentNode > 0)
			{
				flag4 = true;
				if (flag3)
				{
					Vector3 normalized3 = (Path[currentNode] - Path[currentNode - 1]).normalized;
					base.transform.rotation = Quaternion.LookRotation(normalized3);
				}
			}
			num8++;
			num2 -= magnitude2;
			magnitude2 = (Path[currentNode] - base.transform.position).magnitude;
		}
		if (flag4 && currentNode > 0 && num2 > 0f)
		{
			base.transform.position = base.transform.position + (Path[currentNode] - Path[currentNode - 1]).normalized * num2;
		}
	}

	private bool IsClipping(out int x, out int y)
	{
		Vector3 vector = base.transform.position - base.transform.forward;
		int num = Mathf.FloorToInt(vector.x / RoadManager.Instance.RoadSize);
		int num2 = Mathf.FloorToInt(vector.z / RoadManager.Instance.RoadSize);
		x = num;
		y = num2;
		Vector3 vector2 = base.transform.position + base.transform.forward;
		int num3 = Mathf.FloorToInt(vector2.x / RoadManager.Instance.RoadSize);
		int num4 = Mathf.FloorToInt(vector2.z / RoadManager.Instance.RoadSize);
		if (num == num3 && num2 == num4)
		{
			return false;
		}
		if (RoadManager.Instance.GetRoad(num, num2, 0) != 1)
		{
			x = num3;
			y = num4;
			return true;
		}
		if (RoadManager.Instance.GetRoad(num3, num4, 0) != 1)
		{
			return true;
		}
		return false;
	}

	private Vector3 GetPosAt(int offset, float distance)
	{
		if (Path == null || Path.Count == 0)
		{
			return Vector3.zero;
		}
		if (offset >= Path.Count - 1)
		{
			return Path[Path.Count - 1];
		}
		for (int i = offset; i < Path.Count - 1; i++)
		{
			Vector3 vector = Path[i];
			Vector3 vector2 = Path[i + 1] - vector;
			float magnitude = vector2.magnitude;
			if (magnitude > distance)
			{
				return vector + vector2 * (distance / magnitude);
			}
			distance -= magnitude;
		}
		return Path[Path.Count - 1];
	}

	private void OnDrawGizmosSelected()
	{
		if (Car != null && Car.AnyOccupants())
		{
			Car.ForEachOccupant(delegate(Actor item)
			{
				if (item != null)
				{
					if (item.MyCar == Car)
					{
						Gizmos.color = (Car.SpawnPoints[item.CarSpawnID].Occupants.Contains(item) ? Color.green : Color.yellow);
						Gizmos.DrawLine(base.transform.position, item.ActualPosition);
					}
					else
					{
						Gizmos.color = Color.red;
						Gizmos.DrawLine(base.transform.position, item.ActualPosition);
						if (item.MyCar != null)
						{
							Gizmos.DrawLine(item.MyCar.transform.position, item.ActualPosition);
						}
					}
				}
			});
		}
		if (Path != null && Path.Count > 0)
		{
			Gizmos.color = Color.green;
			Gizmos.DrawSphere(Path[0], 0.1f);
			for (int num = 0; num < Path.Count - 1; num++)
			{
				Gizmos.color = ((currentNode < num) ? Color.red : Color.green);
				Vector3 vector = Path[num];
				Vector3 vector2 = Path[num + 1];
				Gizmos.DrawLine(vector, vector2);
				Gizmos.DrawSphere(vector2, 0.1f);
			}
		}
		Gizmos.color = Color.white;
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["NewPath"] = ((Path == null) ? new List<SVector3>() : ((IList<Vector3>)Path).Select((Func<Vector3, SVector3>)((Vector3 x) => x)).ToList());
		dict["GoHome"] = GoHome;
		dict["DeColor3"] = (SVector3)MyColor;
		dict["currentNode"] = currentNode;
		dict["Debug"] = Debug;
		dict["TrafficWait"] = TrafficWait;
		if (IsAI)
		{
			dict["IsAI"] = true;
			dict["Direction"] = _direction;
			dict["PreferredDirections"] = _preferredDirections;
			dict["PathFinished"] = _pathFinished;
		}
		if (Goal != null)
		{
			dict["Goal"] = true;
			dict["GoalId"] = Goal.ID;
			Vector2 pos = Goal.GetPos();
			dict["GoalX"] = (int)pos.x;
			dict["GoalY"] = (int)pos.y;
			dict["GoalZ"] = Goal.GetRoadFloor();
		}
	}

	public bool Deserialize(WriteDictionary dict)
	{
		if (dict.Contains("NewPath"))
		{
			Path = ((IList<SVector3>)dict.Get("NewPath", new List<SVector3>())).Select((Func<SVector3, Vector3>)((SVector3 sVector) => sVector)).ToList();
		}
		else
		{
			Path = (from sVector in dict.Get("Path", new List<SVector3>())
				select Utilities.ToVector3(sVector, 0f)).ToList();
		}
		if (Path.Count == 0)
		{
			Path = null;
		}
		GoHome = dict.Get("GoHome", false);
		currentNode = dict.Get("currentNode", 0);
		Debug = dict.Get("Debug", true);
		TrafficWait = dict.Get("TrafficWait", -1f);
		MyColor = dict.Get("DeColor3", (SVector3)Colors.GetRandom());
		Car.UpdateColor(MyColor);
		Car.BindOccupants();
		IsAI = dict.Get("IsAI", false);
		if (IsAI)
		{
			_direction = dict.Get<Utilities.Direction>("Direction");
			_preferredDirections = dict.Get<Utilities.Direction>("PreferredDirections");
			_pathFinished = dict.Get<bool>("PathFinished");
			if (!_pathFinished && Path != null)
			{
				Vector3 vector = Path.Last();
				RoadSegment segment = RoadManager.Instance.GetSegment(vector, Mathf.FloorToInt((vector.y + 2f) / 4f));
				if (!(segment != null))
				{
					return false;
				}
				_last = segment.FindNode(vector);
				if (_last == null)
				{
					return false;
				}
			}
		}
		if (dict.Get("Goal", false))
		{
			int x = dict.Get("GoalX", 0);
			int y = dict.Get("GoalY", 0);
			int floor = dict.Get("GoalZ", 0);
			int id = dict.Get("GoalId", -1);
			RoadSegment segment2 = RoadManager.Instance.GetSegment(x, y, floor);
			if (segment2 != null)
			{
				if (Car.FireFighter)
				{
					Vector3 p = base.transform.position;
					Goal = segment2.AllNodes.MinInstance((RoadNode z) => (z.transform.position - p).sqrMagnitude);
					Car.Target = Goal;
				}
				else
				{
					RoadNode roadNode = segment2.Parking.FirstOrDefault((RoadNode z) => z.ID == id);
					if (!(roadNode != null))
					{
						return false;
					}
					Goal = roadNode;
					Car.Target = Goal;
					if (Car.Parked || (Path != null && currentNode < Path.Count))
					{
						Goal.Taken = true;
					}
				}
			}
		}
		return true;
	}
}
