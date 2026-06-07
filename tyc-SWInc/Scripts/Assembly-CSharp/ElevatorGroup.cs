using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class ElevatorGroup
{
	[NonSerialized]
	public Furniture[] Elevators;

	private uint[] _elevators;

	public int BaseFloor;

	public int CurrentFloor;

	public int TargetFloor;

	public int Capacity = 10;

	public float Progress;

	public float Penalty;

	public float Wait;

	public float Speed = 2f;

	[NonSerialized]
	public List<Actor> Enqueued = new List<Actor>();

	[NonSerialized]
	public List<Actor> Entering = new List<Actor>();

	[NonSerialized]
	public List<Actor> InTransit = new List<Actor>();

	private uint[] _enqueued;

	private uint[] _entering;

	private uint[] _inTransit;

	private bool _singlePerson;

	public float PathWeight
	{
		get
		{
			return Penalty.MapRange(0f, 1f, 0.5f, 2f);
		}
	}

	public static int FloorFromPosition(Furniture e)
	{
		return Mathf.FloorToInt((e.OriginalPosition.y + 0.5f) / 2f);
	}

	public ElevatorGroup()
	{
	}

	public ElevatorGroup(int baseFloor)
	{
		CurrentFloor = (TargetFloor = (BaseFloor = baseFloor));
	}

	public ElevatorGroup(params Furniture[] elevator)
	{
		CurrentFloor = (TargetFloor = (BaseFloor = elevator.MinSafeInt(FloorFromPosition)));
		Elevators = new Furniture[elevator.Length];
		for (int i = 0; i < elevator.Length; i++)
		{
			elevator[i].EGroup = this;
			Elevators[FloorFromPosition(elevator[i]) - BaseFloor] = elevator[i];
		}
		Capacity = elevator[0].Capacity;
		Speed = elevator[0].MiscPotential;
		UpdateDisplays();
	}

	public void Add(Furniture elevator)
	{
		elevator.EGroup = this;
		int num = FloorFromPosition(elevator);
		Furniture[] array = new Furniture[Elevators.Length + 1];
		int num2 = 0;
		if (num < BaseFloor)
		{
			array[0] = elevator;
			num2 = 1;
			BaseFloor = num;
		}
		else
		{
			array[array.Length - 1] = elevator;
		}
		for (int i = 0; i < Elevators.Length; i++)
		{
			array[i + num2] = Elevators[i];
		}
		Elevators = array;
		UpdateDisplays();
	}

	public static ElevatorGroup Merge(ElevatorGroup a, ElevatorGroup b)
	{
		if (a.BaseFloor > b.BaseFloor)
		{
			ElevatorGroup elevatorGroup = a;
			a = b;
			b = elevatorGroup;
		}
		Furniture[] array = new Furniture[a.Elevators.Length + b.Elevators.Length];
		for (int i = 0; i < a.Elevators.Length; i++)
		{
			array[i] = a.Elevators[i];
		}
		for (int j = 0; j < b.Elevators.Length; j++)
		{
			array[j + a.Elevators.Length] = b.Elevators[j];
			b.Elevators[j].EGroup = a;
		}
		a.Elevators = array;
		MoveCommuters(b.Enqueued, a, a.Enqueued);
		MoveCommuters(b.Entering, a, a.Entering);
		MoveCommuters(b.InTransit, a, a.InTransit);
		a.UpdateDisplays();
		return b;
	}

	private static void MoveCommuters(List<Actor> cs, ElevatorGroup to, List<Actor> csTo)
	{
		for (int i = 0; i < cs.Count; i++)
		{
			cs[i].QueuedForElevator = to;
		}
		csTo.AddRange(cs);
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("[ ");
		for (int i = 0; i < Elevators.Length; i++)
		{
			stringBuilder.Append(FloorFromPosition(Elevators[i]));
			if (i < Elevators.Length - 1)
			{
				stringBuilder.Append("; ");
			}
		}
		stringBuilder.Append(" ]");
		return stringBuilder.ToString();
	}

	public void Split(Furniture with)
	{
		if (Elevators.Length == 1)
		{
			if (Elevators[0] == with)
			{
				ClearOutCommuters(BaseFloor);
				with.EGroup = null;
				GameSettings.Instance.ElevatorGroups.Remove(this);
			}
			return;
		}
		int num = ((with.Parent == null) ? (Array.IndexOf(Elevators, with) + BaseFloor) : FloorFromPosition(with));
		if (num == BaseFloor)
		{
			ClearOutCommuters(BaseFloor);
			Furniture[] array = new Furniture[Elevators.Length - 1];
			for (int i = 1; i < Elevators.Length; i++)
			{
				array[i - 1] = Elevators[i];
			}
			Elevators = array;
			BaseFloor++;
			return;
		}
		if (num == BaseFloor + Elevators.Length - 1)
		{
			ClearOutCommuters(BaseFloor + Elevators.Length - 1);
			Furniture[] array2 = new Furniture[Elevators.Length - 1];
			for (int j = 0; j < Elevators.Length - 1; j++)
			{
				array2[j] = Elevators[j];
			}
			Elevators = array2;
			return;
		}
		int num2 = num + 1;
		int num3 = Elevators.Length - (num2 - BaseFloor);
		int num4 = Elevators.Length - num3 - 1;
		CurrentFloor = Mathf.Min(CurrentFloor, num - 1);
		TargetFloor = Mathf.Min(TargetFloor, num - 1);
		bool flag = true;
		ElevatorGroup elevatorGroup = null;
		if (num3 < 2)
		{
			ClearOutCommuters(BaseFloor + num4 + 1, BaseFloor + num4 + 1 + num3);
			for (int k = 0; k < num3; k++)
			{
				Elevators[num4 + 1 + k].EGroup = null;
				Elevators[num4 + 1 + k].UpdateElevatorDisplay();
			}
			flag = false;
		}
		else
		{
			elevatorGroup = new ElevatorGroup(num2);
			elevatorGroup.Elevators = new Furniture[num3];
			for (int l = 0; l < elevatorGroup.Elevators.Length; l++)
			{
				elevatorGroup.Elevators[l] = Elevators[num4 + 1 + l];
				elevatorGroup.Elevators[l].EGroup = elevatorGroup;
			}
			GameSettings.Instance.ElevatorGroups.Add(elevatorGroup);
			elevatorGroup.PickTargetFloor();
			elevatorGroup.UpdateDisplays();
		}
		if (num4 < 2)
		{
			ClearOutCommuters(BaseFloor, BaseFloor + num4 + 1);
			for (int m = 0; m < num4; m++)
			{
				Elevators[m].EGroup = null;
				Elevators[m].UpdateElevatorDisplay();
			}
			GameSettings.Instance.ElevatorGroups.Remove(this);
			if (elevatorGroup != null)
			{
				for (int n = 0; n < InTransit.Count; n++)
				{
					Actor actor = InTransit[n];
					actor.QueuedForElevator = elevatorGroup;
					elevatorGroup.InTransit.Add(actor);
				}
				InTransit.Clear();
				for (int num5 = 0; num5 < Enqueued.Count; num5++)
				{
					Actor actor2 = Enqueued[num5];
					actor2.QueuedForElevator = elevatorGroup;
					elevatorGroup.Enqueued.Add(actor2);
				}
				Enqueued.Clear();
				for (int num6 = 0; num6 < Entering.Count; num6++)
				{
					Actor actor3 = Entering[num6];
					actor3.QueuedForElevator = elevatorGroup;
					elevatorGroup.Entering.Add(actor3);
				}
				Entering.Clear();
			}
			flag = false;
		}
		else
		{
			Furniture[] array3 = new Furniture[num4];
			for (int num7 = 0; num7 < array3.Length; num7++)
			{
				array3[num7] = Elevators[num7];
			}
			Elevators = array3;
			UpdateDisplays();
		}
		if (flag)
		{
			SplitCommuters(num, elevatorGroup);
		}
	}

	private void ClearOutCommuters(int on)
	{
		ClearOutCommuters(on, on + 1);
	}

	private void ClearOutCommuters(int from, int to)
	{
		for (int i = 0; i < InTransit.Count; i++)
		{
			Actor actor = InTransit[i];
			if (actor == null)
			{
				InTransit.RemoveAt(i);
				i--;
				continue;
			}
			int floor = actor.Floor;
			if ((actor.TargetFloor >= from && actor.TargetFloor < to) || (floor >= from && floor < to))
			{
				FinishRide(actor);
				InTransit.RemoveAt(i);
				i--;
			}
		}
		for (int j = 0; j < Entering.Count; j++)
		{
			Actor actor2 = Entering[j];
			if (actor2 == null)
			{
				Entering.RemoveAt(j);
				j--;
				continue;
			}
			int floor2 = actor2.Floor;
			if ((actor2.TargetFloor >= from && actor2.TargetFloor < to) || (floor2 >= from && floor2 < to))
			{
				actor2.ResetState();
				j--;
			}
		}
		for (int k = 0; k < Enqueued.Count; k++)
		{
			Actor actor3 = Enqueued[k];
			if (actor3 == null)
			{
				Enqueued.RemoveAt(k);
				k--;
				continue;
			}
			int floor3 = actor3.Floor;
			if ((actor3.TargetFloor >= from && actor3.TargetFloor < to) || (floor3 >= from && floor3 < to))
			{
				actor3.ResetState();
				k--;
			}
		}
	}

	private void SplitCommuters(int split, ElevatorGroup to)
	{
		for (int i = 0; i < InTransit.Count; i++)
		{
			Actor actor = InTransit[i];
			if (actor.TargetFloor == split)
			{
				FinishRide(actor);
				InTransit.RemoveAt(i);
				i--;
			}
			else if (actor.TargetFloor > split)
			{
				actor.QueuedForElevator = to;
				to.InTransit.Add(actor);
				InTransit.RemoveAt(i);
				i--;
			}
		}
		for (int j = 0; j < Entering.Count; j++)
		{
			Actor actor2 = Entering[j];
			int floor = actor2.Floor;
			if (actor2.TargetFloor == split || floor == split || ((actor2.TargetFloor > split) ^ (floor > split)))
			{
				actor2.ResetState();
				j--;
			}
			else if (actor2.TargetFloor > split && floor > split)
			{
				actor2.QueuedForElevator = to;
				to.Entering.Add(actor2);
				Entering.RemoveAt(j);
				j--;
			}
		}
		for (int k = 0; k < Enqueued.Count; k++)
		{
			Actor actor3 = Enqueued[k];
			int floor2 = actor3.Floor;
			if (actor3.TargetFloor == split || floor2 == split || ((actor3.TargetFloor > split) ^ (floor2 > split)))
			{
				actor3.ResetState();
				k--;
			}
			else if (actor3.TargetFloor > split && floor2 > split)
			{
				actor3.QueuedForElevator = to;
				to.Enqueued.Add(actor3);
				Enqueued.RemoveAt(k);
				k--;
			}
		}
	}

	private bool PickTargetFloor()
	{
		if (TargetFloor != CurrentFloor)
		{
			return true;
		}
		if (InTransit.Count == 0 && Enqueued.Count == 0)
		{
			return false;
		}
		int num = CurrentFloor;
		int num2 = CurrentFloor;
		for (int i = 0; i < InTransit.Count; i++)
		{
			num = Mathf.Min(num, InTransit[i].TargetFloor);
			num2 = Mathf.Max(num2, InTransit[i].TargetFloor);
		}
		for (int j = 0; j < Enqueued.Count; j++)
		{
			int floor = Enqueued[j].Floor;
			num = Mathf.Min(num, floor);
			num2 = Mathf.Max(num2, floor);
		}
		TargetFloor = ((CurrentFloor - num > num2 - CurrentFloor) ? num : num2);
		return true;
	}

	public void PrepareSerialize()
	{
		_enqueued = Enqueued.NotNullSelect((Actor x) => x.DID).ToArray();
		_entering = Entering.NotNullSelect((Actor x) => x.DID).ToArray();
		_inTransit = InTransit.NotNullSelect((Actor x) => x.DID).ToArray();
		_elevators = ((Elevators == null) ? new uint[0] : Elevators.NotNullSelect((Furniture x) => x.DID).ToArray());
	}

	public bool Deserialize()
	{
		if (_entering != null)
		{
			Entering.AddRange(_entering.SelectNotNull((uint x) => Writeable.STGetDeserializedObject(x) as Actor));
			Enqueued.AddRange(_enqueued.SelectNotNull((uint x) => Writeable.STGetDeserializedObject(x) as Actor));
			InTransit.AddRange(_inTransit.SelectNotNull((uint x) => Writeable.STGetDeserializedObject(x) as Actor));
			Elevators = _elevators.SelectInPlace((uint x) => Writeable.STGetDeserializedObject(x) as Furniture);
			_enqueued = null;
			_entering = null;
			_inTransit = null;
			_elevators = null;
			if (Elevators.Any((Furniture x) => x == null))
			{
				Enqueued.ForEach(delegate(Actor x)
				{
					x.ClearPath();
				});
				Entering.ForEach(delegate(Actor x)
				{
					x.ClearPath();
				});
				InTransit.ForEach(delegate(Actor x)
				{
					x.ClearPath();
				});
				for (int num = 0; num < Elevators.Length; num++)
				{
					Furniture furniture = Elevators[num];
					if (furniture != null)
					{
						furniture.UpdateElevatorConnections();
					}
				}
				return false;
			}
			Enqueued.ForEach(delegate(Actor x)
			{
				x.QueuedForElevator = this;
			});
			Entering.ForEach(delegate(Actor x)
			{
				x.QueuedForElevator = this;
			});
			InTransit.ForEach(delegate(Actor x)
			{
				x.QueuedForElevator = this;
			});
			Elevators.ForEachEnum(delegate(Furniture x)
			{
				x.EGroup = this;
			});
			UpdateDisplays();
		}
		return true;
	}

	public void Enqueue(Actor a)
	{
		a.EState = Actor.ElevatorState.Queued;
		a.QueuedForElevator = this;
		Enqueued.Add(a);
		if (CurrentFloor == TargetFloor && Progress == 0f)
		{
			PickTargetFloor();
		}
	}

	public void Enter(Actor a)
	{
		a.EState = Actor.ElevatorState.InTransit;
		if (!Entering.Remove(a))
		{
			return;
		}
		InTransit.Add(a);
		if (Entering.Count == 0)
		{
			if (InTransit.Count < Capacity)
			{
				Wait = 2f;
			}
			else
			{
				ToggleDoors(a.Floor, false, false);
			}
			if (CurrentFloor == TargetFloor)
			{
				PickTargetFloor();
			}
		}
		UpdateDisplays();
	}

	public void Remove(Actor a)
	{
		Enqueued.Remove(a);
		if (Entering.Remove(a) && a.employee.HasTrait(Employee.Trait.SilentButDeadly))
		{
			_singlePerson = false;
		}
		if (InTransit.Remove(a) && a.employee.HasTrait(Employee.Trait.SilentButDeadly))
		{
			_singlePerson = false;
		}
	}

	public bool CheckQueued()
	{
		if (Enqueued.Count > 0 && !_singlePerson && InTransit.Count + Entering.Count < Capacity)
		{
			bool result = false;
			int num = Capacity - InTransit.Count - Entering.Count;
			for (int i = 0; i < Enqueued.Count; i++)
			{
				if (num <= 0)
				{
					break;
				}
				Actor actor = Enqueued[i];
				if (actor == null)
				{
					Enqueued.RemoveAt(i);
					i--;
				}
				else
				{
					if (actor.Floor != CurrentFloor)
					{
						continue;
					}
					if (InTransit.Count + Entering.Count == 0 || !actor.employee.HasTrait(Employee.Trait.SilentButDeadly))
					{
						ToggleDoors(CurrentFloor, true, true);
						result = true;
						actor.EState = Actor.ElevatorState.Entering;
						Enqueued.RemoveAt(i);
						Entering.Add(actor);
						num--;
						i--;
						Wait = 0f;
						if (actor.employee.HasTrait(Employee.Trait.SilentButDeadly))
						{
							actor.SetTraitView(Employee.Trait.SilentButDeadly, 0, 20, true);
							_singlePerson = true;
							break;
						}
					}
					else
					{
						actor.SetTraitView(Employee.Trait.SilentButDeadly, 0, 20, true);
					}
				}
			}
			return result;
		}
		return false;
	}

	public void AddPenalty()
	{
		if (Penalty >= 1f)
		{
			Penalty += 1f / Penalty / (float)Capacity;
		}
		else
		{
			Penalty += 1f / (float)Capacity;
		}
		UpdatePenalty(0f);
	}

	public void UpdatePenalty(float delta)
	{
		Penalty = Mathf.Max(0f, Penalty - Utilities.PerHour(0.25f, delta, false));
		float pathWeight = PathWeight;
		for (int i = 0; i < Elevators.Length; i++)
		{
			Furniture furniture = Elevators[i];
			if (furniture != null)
			{
				furniture.UpdateWeight(pathWeight);
			}
		}
	}

	private void ToggleDoors(int floor, bool open, bool keepOpen)
	{
		int num = floor - BaseFloor;
		if (num >= 0 && num < Elevators.Length)
		{
			Furniture furniture = Elevators[num];
			if (furniture != null)
			{
				furniture.ToggleDoors(open, keepOpen);
			}
		}
	}

	public void Tick(float delta)
	{
		UpdatePenalty(delta);
		if (_singlePerson && Entering.Count == 0 && InTransit.Count == 0)
		{
			_singlePerson = false;
		}
		if (Entering.Count > 0)
		{
			for (int i = 0; i < Entering.Count; i++)
			{
				Actor actor = Entering[i];
				if (!actor.IsAliveNotNull() || actor.EState != Actor.ElevatorState.Entering)
				{
					Entering.RemoveAt(i);
					i--;
				}
			}
			CheckQueued();
			Elevators[0].IsOn = false;
			return;
		}
		if (Wait > 0f)
		{
			Wait -= delta;
			if (CheckQueued())
			{
				Elevators[0].IsOn = false;
				return;
			}
			if (!(Wait <= 0f))
			{
				Elevators[0].IsOn = false;
				return;
			}
			ToggleDoors(CurrentFloor, false, false);
		}
		if (CurrentFloor == TargetFloor)
		{
			if (!CheckQueued())
			{
				PickTargetFloor();
			}
			Elevators[0].IsOn = false;
			return;
		}
		if (CurrentFloor == TargetFloor)
		{
			Elevators[0].IsOn = false;
			return;
		}
		Elevators[0].UseModifier = Mathf.Max(1f, InTransit.Count) / (float)Elevators[0].Capacity;
		Elevators[0].IsOn = true;
		Progress += delta * Speed;
		while (Progress > 1f)
		{
			Progress -= 1f;
			if (CurrentFloor < TargetFloor)
			{
				CurrentFloor++;
			}
			else
			{
				CurrentFloor--;
			}
			for (int j = 0; j < InTransit.Count; j++)
			{
				Actor actor2 = InTransit[j];
				if (actor2.TargetFloor == CurrentFloor)
				{
					ToggleDoors(CurrentFloor, true, false);
					Wait = 2f;
					InTransit.RemoveAt(j);
					FinishRide(actor2);
					j--;
				}
			}
			UpdateDisplays();
			if (CheckQueued())
			{
				Progress = 0f;
				break;
			}
			if (CurrentFloor == TargetFloor && !PickTargetFloor())
			{
				Progress = 0f;
				break;
			}
		}
	}

	private void FinishRide(Actor a)
	{
		if (!(a != null) || a.QueuedForElevator != this)
		{
			return;
		}
		if (a.employee.HasTrait(Employee.Trait.SilentButDeadly))
		{
			_singlePerson = false;
		}
		a.QueuedForElevator = null;
		a.EState = Actor.ElevatorState.None;
		if (a.CurrentPath != null)
		{
			a.CurrentPathNode = Mathf.Min(a.CurrentPathNode + 1, a.CurrentPath.Count - 1);
			PathVector pathVector = a.CurrentPath[a.CurrentPathNode];
			a.ActualPosition = pathVector;
			if (a.CurrentPathNode + 1 < a.CurrentPath.Count)
			{
				PathVector pathVector2 = a.CurrentPath[a.CurrentPathNode + 1];
				a.transform.rotation = Quaternion.LookRotation(pathVector2 - pathVector);
			}
			a.UpdateCurrentRoom();
		}
	}

	public bool IsUsing(Actor a)
	{
		if (!Enqueued.Contains(a) && !InTransit.Contains(a))
		{
			return Entering.Contains(a);
		}
		return true;
	}

	private void UpdateDisplays()
	{
		int move = Utilities.Sign(TargetFloor - CurrentFloor);
		for (int i = 0; i < Elevators.Length; i++)
		{
			Furniture furniture = Elevators[i];
			if (furniture != null)
			{
				furniture.UpdateElevatorDisplay(CurrentFloor, move, InTransit.Count);
			}
		}
	}
}
