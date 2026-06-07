using System;
using UnityEngine;

public class ActorStateBehaviour : StateMachineBehaviour
{
	public enum ActorEvent
	{
		None = 0,
		OpenVanDoor = 1,
		CloseCarDoor = 2,
		OpenCarDoor = 3,
		CarEntered = 4,
		InBed = 5,
		OnBike = 6,
		ResetTrigger = 7
	}

	public enum EventTiming
	{
		Start = 0,
		Exit = 1,
		Time = 2
	}

	public ActorEvent Event;

	public EventTiming Timing = EventTiming.Exit;

	public float Time;

	public bool TryGetActor(Animator animator, out Actor ac)
	{
		return animator.transform.parent.TryGetComponent<Actor>(out ac);
	}

	public void TriggerEvent(Animator animator)
	{
		Actor ac;
		if (TryGetActor(animator, out ac))
		{
			TriggerEvent(ac);
		}
	}

	public void TriggerEvent(Actor ac)
	{
		ac.LastTrigger = Event;
		if (Event != ActorEvent.ResetTrigger)
		{
			switch (Event)
			{
			case ActorEvent.OpenVanDoor:
				OpenVanDoor(ac);
				break;
			case ActorEvent.CloseCarDoor:
				CloseCarDoor(ac);
				break;
			case ActorEvent.OpenCarDoor:
				OpenCarDoor(ac);
				break;
			case ActorEvent.CarEntered:
				CarEntered(ac);
				break;
			case ActorEvent.InBed:
				InBed(ac);
				break;
			case ActorEvent.OnBike:
				OnBike(ac);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		if (Timing == EventTiming.Start)
		{
			TriggerEvent(animator);
		}
	}

	public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Actor ac;
		if (Timing == EventTiming.Exit)
		{
			TriggerEvent(animator);
		}
		else if (Timing == EventTiming.Time && TryGetActor(animator, out ac) && ac.LastTrigger != Event)
		{
			TriggerEvent(ac);
		}
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Actor ac;
		if (Timing == EventTiming.Time && stateInfo.normalizedTime >= Time && TryGetActor(animator, out ac) && ac.LastTrigger != Event)
		{
			TriggerEvent(ac);
		}
	}

	public void OpenVanDoor(Actor Parent)
	{
		if (Parent.MyCar != null && Parent.MyCar.SpawnPoints.Length > 2)
		{
			Parent.MyCar.SpawnPoints[2].OpenDoor();
		}
		Parent.SetAnim(Actor.AnimationStates.Idle);
	}

	public void CloseCarDoor(Actor Parent)
	{
		if (Parent.MyCar != null)
		{
			Parent.MyCar.SpawnPoints[Parent.CarSpawnID].CloseDoor();
		}
	}

	public void OpenCarDoor(Actor Parent)
	{
		if (Parent.MyCar != null)
		{
			Parent.MyCar.SpawnPoints[Parent.CarSpawnID].OpenDoor();
		}
	}

	public void CarEntered(Actor Parent)
	{
		if (Parent.MyCar != null)
		{
			CarSpawn carSpawn = Parent.MyCar.SpawnPoints[Parent.CarSpawnID];
			if (!carSpawn.AutoCloseDoor)
			{
				carSpawn.CloseDoor();
			}
			carSpawn.Occupants.Remove(Parent);
			Parent.MyCar = null;
		}
		if (Parent.AIScript.currentNode.Name.Equals("Despawn"))
		{
			Parent.AIScript.currentNode.Run(Parent);
			Parent.AIScript.currentNode = AI.DummyNode;
		}
	}

	public void InBed(Actor Parent)
	{
		Vector3 eulerAngles = Parent.transform.rotation.eulerAngles;
		if (Parent.UsingPoint != null)
		{
			Parent.transform.rotation = Quaternion.Euler(eulerAngles.x, Parent.UsingPoint.Rotation, eulerAngles.z);
			Parent.UsingPoint.Parent.InteractStart();
		}
		Parent.AIScript.currentNode = Parent.AIScript.BehaviorNodes["Despawn"];
		Parent.AIScript.currentNode.Run(Parent);
		Parent.AIScript.currentNode = AI.DummyNode;
	}

	public void OnBike(Actor Parent)
	{
		if (Parent.MyCar != null)
		{
			BikeScript component = Parent.MyCar.GetComponent<BikeScript>();
			if (component != null)
			{
				component.GoHome = true;
				component.SetRider(Parent, false);
				return;
			}
		}
		if (Parent.AIScript.currentNode.Name.Equals("Despawn"))
		{
			Parent.AIScript.currentNode.Run(Parent);
			Parent.AIScript.currentNode = AI.DummyNode;
		}
	}
}
