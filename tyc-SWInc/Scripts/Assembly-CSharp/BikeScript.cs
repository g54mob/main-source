using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BikeScript : MonoBehaviour
{
	public CarScript Car;

	public bool GoHome;

	public float PaddleSpeed = 360f;

	public float PaddeOffset;

	public int CurrentNode;

	[NonSerialized]
	public List<Vector3> Path;

	public RoadNode Goal;

	public Color MyColor;

	public Gradient ColorPick;

	public Transform SitPos;

	public Transform PaddleFrame;

	public Transform[] Paddles;

	public Actor Rider;

	public LODGroup LOD;

	private static List<Vector3> _pathCache = new List<Vector3>();

	private static ObjectPool<List<Vector3>> _pathPool = new ObjectPool<List<Vector3>>(() => new List<Vector3>(), delegate(List<Vector3> x)
	{
		x.Clear();
	});

	public void Reset()
	{
		GoHome = false;
		CurrentNode = 0;
		Goal = null;
		if (Path != null)
		{
			_pathPool.Release(Path);
			Path = null;
		}
		Rider = null;
	}

	public void Init()
	{
		if (Car.AnyOccupants())
		{
			Car.CanDestroy = false;
			Car.CurrentSpeed = Car.Speed * UnityEngine.Random.value;
			Goal = Car.Target;
			if (Goal == null)
			{
				if (Car.AnyOccupants())
				{
					Car.ForEachOccupant(delegate(Actor x)
					{
						GameSettings.Instance.sActorManager.ReadyForBus.Add(x);
					});
				}
				RoadManager.Instance.DestroyCar(Car);
				return;
			}
			RoadSegment parent = RoadManager.Instance.GetInputs().MinInstance((RoadNode x) => x.GetPos().ManhattanDist(Goal.GetPos())).Parent;
			if (parent == null)
			{
				if (Car.AnyOccupants())
				{
					Car.ForEachOccupant(delegate(Actor x)
					{
						GameSettings.Instance.sActorManager.ReadyForBus.Add(x);
					});
				}
				RoadManager.Instance.DestroyCar(Car);
				return;
			}
			if (RoadManager.Instance.FindPath(parent, Goal.Parent, false, _pathCache))
			{
				FixPath(false);
				Vector3 vector = Goal.transform.forward * 0.2f;
				Path.Add(Goal.transform.position - vector);
				Path.Add(Goal.transform.position + vector);
				if (Goal.Parking)
				{
					Goal.Taken = true;
				}
				base.transform.SetPositionAndRotation(Path[0], Quaternion.LookRotation(Path[1] - Path[0]));
				MyColor = ColorPick.Evaluate(UnityEngine.Random.value);
				Car.UpdateColor(MyColor);
				SetRider(Car.FirstActor(), true);
				return;
			}
			if (Car.AnyOccupants())
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
		}
		else
		{
			RoadManager.Instance.DestroyCar(Car);
		}
	}

	public void FixPath(bool home)
	{
		if (Path == null)
		{
			Path = _pathPool.Get();
		}
		else
		{
			Path.Clear();
		}
		if (home)
		{
			_pathCache.Add(_pathCache[_pathCache.Count - 1] + (_pathCache[_pathCache.Count - 1] - _pathCache[_pathCache.Count - 2]));
		}
		else
		{
			_pathCache.Insert(0, _pathCache[0] - (_pathCache[1] - _pathCache[0]));
		}
		float num = (home ? base.transform.rotation.eulerAngles.y : 0f);
		bool flag = (home ? RoomManager.GetRoadRight(num, base.transform.position) : (UnityEngine.Random.value > 0.5f));
		for (int i = 0; i < _pathCache.Count - 1; i++)
		{
			Vector3 v = _pathCache[i];
			Vector3 vector = _pathCache[i + 1];
			Quaternion quaternion = Quaternion.LookRotation(vector.ReplaceY(0f) - v.ReplaceY(0f));
			float y = quaternion.eulerAngles.y;
			float num2 = Mathf.DeltaAngle(num, y);
			if (!Mathf.Approximately(num2, 0f) && num2 > 0f != flag)
			{
				flag = !flag;
			}
			float num3 = UnityEngine.Random.Range(-0.2f, 0.2f);
			Vector3 vector2 = (flag ? new Vector3(3f + num3, 0f, -4f) : new Vector3(-3f + num3, 0f, -4f));
			Vector3 v2 = vector + quaternion * vector2;
			Path.Add(v2.ReplaceY(RoadManager.Instance.SampleHeight(v2.ReplaceY(Mathf.Max(v.y, vector.y)))));
			num = y;
		}
	}

	public void SetRider(Actor actor, bool forceAnim)
	{
		Rider = actor;
		Rider.MyCar = Car;
		Rider.transform.SetParent(SitPos, true);
		Rider.transform.localPosition = Vector3.zero;
		Rider.transform.localRotation = Quaternion.identity;
		Rider.SetAnim(Actor.AnimationStates.Cycle);
		Rider.enabled = true;
		Rider.SetVisible(true);
		Rider.anim.enabled = true;
		if (forceAnim)
		{
			Rider.anim.Play("Cycle", 0, 0f);
		}
		Rider.Biking = true;
	}

	private void Update()
	{
		if (GameSettings.GameSpeed == 0f || Car.Delay > 0f)
		{
			return;
		}
		if (Path == null)
		{
			RoadManager.Instance.DestroyCar(Car);
			return;
		}
		float num = Time.deltaTime * GameSettings.GameSpeed;
		if (CurrentNode >= Path.Count)
		{
			if (Goal == null)
			{
				RoadManager.Instance.DestroyCar(Car);
			}
			else if (GoHome)
			{
				Car.Parked = false;
				Goal.Taken = false;
				Car.CanDestroy = true;
				RoadSegment parent = RoadManager.Instance.GetOutputs().MinInstance((RoadNode x) => x.GetPos().ManhattanDist(Goal.GetPos())).Parent;
				if (RoadManager.Instance.FindPath(Goal.Parent, parent, true, _pathCache))
				{
					FixPath(true);
				}
				else if (Path != null)
				{
					_pathPool.Release(Path);
					Path = null;
				}
				Goal = null;
				CurrentNode = 0;
				Car.LightsE = true;
				Car.AudioE = true;
				if (Path == null)
				{
					RoadManager.Instance.DestroyCar(Car);
				}
			}
			else if (!Car.AnyLiveOccupants(true))
			{
				GoHome = true;
			}
			else if (!Car.IsSpawning() && Car.AnyDeadOccupants())
			{
				Car.BeginSpawn();
			}
			return;
		}
		if (Rider != null && CameraScript.Instance.mainCam.transform.position.y - base.transform.position.y < 30f)
		{
			PaddleFrame.localRotation = Quaternion.Euler(0f, 0f, Rider.anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f * PaddleSpeed + PaddeOffset);
			for (int num2 = 0; num2 < Paddles.Length; num2++)
			{
				Paddles[num2].localRotation = Quaternion.Euler(0f, 90f, 90f);
				Vector3 eulerAngles = Paddles[num2].rotation.eulerAngles;
				Paddles[num2].rotation = Quaternion.Euler(90f, eulerAngles.y, eulerAngles.z);
			}
		}
		Vector3 position = base.transform.position;
		float num3 = Car.CurrentSpeed * num;
		Vector3 vector = Path[CurrentNode] - position;
		float magnitude = vector.magnitude;
		Vector3 vector2 = vector;
		bool flag = vector2 == Vector3.zero;
		if (!flag && magnitude >= num3)
		{
			vector2 *= num3 / magnitude;
			flag = vector2 == Vector3.zero;
			num3 = 0f;
		}
		else
		{
			num3 -= magnitude;
		}
		Vector3 normalized = (GetPosAt(CurrentNode, magnitude + 2f) - base.transform.position).normalized;
		float num4 = (180f - Mathf.Abs(Vector3.Angle(base.transform.forward, normalized))) / 180f;
		num4 = Mathf.Max(0.2f, num4 * num4);
		if (Goal != null && Goal.Parking)
		{
			float num5 = 5f;
			if (CurrentNode < Path.Count - 2)
			{
				num5 = Car.Speed * num4;
			}
			float num6 = ((Car.CurrentSpeed < num5) ? (Car.Speed / 8f) : Car.Speed);
			Car.CurrentSpeed = Mathf.Lerp(Car.CurrentSpeed, num5, num * num6);
		}
		else
		{
			float num7 = num4 * Car.Speed;
			float num8 = ((Car.CurrentSpeed < num7) ? (Car.Speed / 8f) : Car.Speed);
			Car.CurrentSpeed = Mathf.Lerp(Car.CurrentSpeed, num7, num * num8);
		}
		Vector3 position2 = base.transform.position + vector2;
		if (!flag)
		{
			base.transform.SetPositionAndRotation(position2, Quaternion.Lerp(base.transform.rotation, Quaternion.LookRotation(vector2), num * Car.CurrentSpeed));
		}
		else
		{
			base.transform.position = position2;
		}
		if (!(num3 > 0f))
		{
			return;
		}
		bool flag2 = num3 > 1f;
		int num9 = 0;
		float magnitude2 = (Path[CurrentNode] - base.transform.position).magnitude;
		bool flag3 = false;
		while (magnitude2 <= num3)
		{
			if (num9 > 25)
			{
				flag3 = false;
				break;
			}
			base.transform.position = Path[CurrentNode];
			CurrentNode++;
			if (CurrentNode == Path.Count)
			{
				if (Goal != null && Goal.Parking)
				{
					if (!Car.AnyLiveOccupants())
					{
						GoHome = true;
						return;
					}
					Vector3 normalized2 = (Path[CurrentNode - 1] - Path[CurrentNode - 2]).normalized;
					base.transform.rotation = Quaternion.LookRotation(normalized2);
					Car.BindOccupants();
					Car.BeginSpawn();
					Car.Parked = true;
					Car.CurrentSpeed = 0f;
					Car.LightsE = false;
					Car.AudioE = false;
				}
				else
				{
					RoadManager.Instance.DestroyCar(Car);
				}
				flag3 = false;
				break;
			}
			if (CurrentNode > 0)
			{
				flag3 = true;
				if (flag2)
				{
					Vector3 normalized3 = (Path[CurrentNode] - Path[CurrentNode - 1]).normalized;
					base.transform.rotation = Quaternion.LookRotation(normalized3);
				}
			}
			num9++;
			num3 -= magnitude2;
			magnitude2 = (Path[CurrentNode] - base.transform.position).magnitude;
		}
		if (flag3 && CurrentNode > 0 && num3 > 0f)
		{
			base.transform.position = base.transform.position + (Path[CurrentNode] - Path[CurrentNode - 1]).normalized * num3;
		}
	}

	private Vector3 GetPosAt(int offset, float distance)
	{
		if (Path.Count == 0)
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

	public void DestroyEvent()
	{
		if (Rider != null && Rider.enabled && Rider.transform.parent == SitPos)
		{
			Rider.transform.SetParent(null, true);
			if (Rider.MyCar == Car)
			{
				Rider.MyCar = null;
				Rider.Biking = false;
			}
			if (Rider.AIScript.currentNode.Name.Equals("Despawn"))
			{
				Rider.AIScript.currentNode.Run(Rider);
				Rider.AIScript.currentNode = AI.DummyNode;
			}
		}
		if (Path != null)
		{
			_pathPool.Release(Path);
			Path = null;
		}
		if (Goal != null && !GoHome)
		{
			Goal.Taken = false;
		}
	}

	public void Serialize(WriteDictionary dict)
	{
		dict["Path"] = ((Path == null) ? new List<SVector3>() : ((IList<Vector3>)Path).Select((Func<Vector3, SVector3>)((Vector3 x) => x)).ToList());
		dict["GoHome"] = GoHome;
		dict["DeColor3"] = (SVector3)MyColor;
		dict["CurrentNode"] = CurrentNode;
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
		List<SVector3> list = dict.Get<List<SVector3>>("Path", null);
		if (list != null)
		{
			Path = _pathPool.Get();
			Path.AddRange(list.Select((SVector3 sVector) => sVector.ToVector3()));
		}
		GoHome = dict.Get("GoHome", false);
		CurrentNode = dict.Get("CurrentNode", 0);
		MyColor = dict.Get("DeColor3", (SVector3)ColorPick.Evaluate(UnityEngine.Random.value));
		Car.UpdateColor(MyColor);
		Car.BindOccupants();
		if (dict.Get("Goal", false))
		{
			int x = dict.Get("GoalX", 0);
			int y = dict.Get("GoalY", 0);
			int floor = dict.Get("GoalZ", 0);
			int id = dict.Get("GoalId", -1);
			RoadSegment segment = RoadManager.Instance.GetSegment(x, y, floor);
			if (segment != null)
			{
				RoadNode roadNode = segment.Parking.FirstOrDefault((RoadNode z) => z.ID == id);
				if (!(roadNode != null))
				{
					return false;
				}
				Goal = roadNode;
				Car.Target = Goal;
				if (Car.Parked || (Path != null && CurrentNode < Path.Count))
				{
					Goal.Taken = true;
				}
			}
		}
		Actor actor = Car.FirstActor();
		if (actor != null && actor.Biking)
		{
			SetRider(actor, false);
		}
		return true;
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
				Gizmos.color = ((CurrentNode < num) ? Color.red : Color.green);
				Vector3 vector = Path[num];
				Vector3 vector2 = Path[num + 1];
				Gizmos.DrawLine(vector, vector2);
				Gizmos.DrawSphere(vector2, 0.1f);
			}
		}
		Gizmos.color = Color.white;
	}
}
