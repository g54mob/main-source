using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Patrol")]
	public class PatrolTask : MTask
	{
		[Tooltip("The Animal will Rotate/Look at the Target when he arrives to it")]
		public bool LookAtOnArrival;

		[Tooltip("Ignores the Wait time of all waypoints")]
		public bool IgnoreWaitTime;

		public PatrolType patrolType;

		[Tooltip("Use a Runtime GameObjects Set to find the Next waypoint")]
		public RuntimeGameObjects RuntimeSet;

		public RuntimeSetTypeGameObject rtype = RuntimeSetTypeGameObject.Random;

		public IntReference RTIndex = new IntReference();

		public StringReference RTName = new StringReference();

		public override string DisplayName => "Movement/Patrol";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			brain.AIControl.AutoNextTarget = true;
			switch (patrolType)
			{
			case PatrolType.LastWaypoint:
				if (brain.LastWayPoint != null)
				{
					brain.TargetAnimal = null;
					brain.AIControl.SetTarget(brain.LastWayPoint.WPTransform, move: true);
				}
				break;
			case PatrolType.UseRuntimeSet:
				if (RuntimeSet != null)
				{
					brain.TargetAnimal = null;
					GameObject item2 = RuntimeSet.GetItem(rtype, RTIndex, RTName, brain.Animal.gameObject);
					if ((bool)item2)
					{
						brain.AIControl.SetTarget(item2.transform, move: true);
					}
				}
				break;
			case PatrolType.LocalRuntimeSet:
			{
				GetRuntimeGameObjects component = brain.GetComponent<GetRuntimeGameObjects>();
				if (component != null && component.Collection != null)
				{
					GameObject item = component.Collection.GetItem(rtype, RTIndex, RTName, brain.Animal.gameObject);
					if ((bool)item)
					{
						brain.AIControl.SetTarget(item.transform, move: true);
					}
				}
				break;
			}
			}
			brain.AIControl.LookAtTargetOnArrival = LookAtOnArrival;
			brain.TaskDone(index);
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			brain.AIControl.StopWait();
		}

		public override void OnTargetArrived(MAnimalBrain brain, Transform Target, int index)
		{
			brain.AIControl.AutoNextTarget = true;
			switch (patrolType)
			{
			case PatrolType.LastWaypoint:
				if (IgnoreWaitTime)
				{
					brain.AIControl.StopWait();
					brain.AIControl.SetTarget(brain.AIControl.NextTarget, move: true);
				}
				break;
			case PatrolType.UseRuntimeSet:
			{
				GameObject item2 = RuntimeSet.GetItem(rtype, RTIndex, RTName, brain.Animal.gameObject);
				if ((bool)item2 && brain.AIControl.NextTarget == null)
				{
					if (IgnoreWaitTime)
					{
						brain.AIControl.StopWait();
						brain.AIControl.SetTarget(item2.transform, move: true);
					}
					else
					{
						brain.AIControl.SetNextTarget(item2);
						brain.AIControl.MovetoNextTarget();
					}
				}
				break;
			}
			case PatrolType.LocalRuntimeSet:
			{
				GetRuntimeGameObjects component = brain.GetComponent<GetRuntimeGameObjects>();
				if (!(component != null) || !(component.Collection != null))
				{
					break;
				}
				GameObject item = component.Collection.GetItem(rtype, RTIndex, RTName, brain.Animal.gameObject);
				if ((bool)item)
				{
					brain.AIControl.SetTarget(item.transform, move: true);
				}
				if ((bool)item && brain.AIControl.NextTarget == null)
				{
					if (IgnoreWaitTime)
					{
						brain.AIControl.StopWait();
						brain.AIControl.SetTarget(item.transform, move: true);
					}
					else
					{
						brain.AIControl.SetNextTarget(item);
						brain.AIControl.MovetoNextTarget();
					}
				}
				break;
			}
			}
		}

		private void Reset()
		{
			Description = "Simple Patrol Logic using the Default AiAnimal Control Movement System";
		}
	}
}
