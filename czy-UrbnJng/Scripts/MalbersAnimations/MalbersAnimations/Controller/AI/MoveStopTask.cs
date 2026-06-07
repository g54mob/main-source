using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Movement Task", fileName = "New Move Task")]
	public class MoveStopTask : MTask
	{
		public enum MoveType
		{
			MoveToCurrentTarget = 0,
			MoveToNextTarget = 1,
			LockAnimalMovement = 2,
			Stop = 3,
			RotateInPlace = 4,
			Flee = 5,
			CircleAround = 6,
			KeepDistance = 7,
			MoveToLastKnownDestination = 8
		}

		public enum CircleDirection
		{
			Left = 0,
			Right = 1
		}

		[Space]
		[Tooltip("Type of the Movement task")]
		public MoveType task;

		public FloatReference distance = new FloatReference(10f);

		public FloatReference distanceThreshold = new FloatReference(1f);

		public FloatReference stoppingDistance = new FloatReference(0.5f);

		public FloatReference slowingDistance = new FloatReference(0f);

		public CircleDirection direction;

		public int arcsCount = 12;

		public bool LookAtTarget;

		[Tooltip("It will flee from the Target forever. If this value is false it will flee once it has reached a safe distance and the Task will end.")]
		public bool FleeForever = true;

		[Tooltip("The AI will stop if it arrives to the current target")]
		public bool StopOnArrive = true;

		public Color debugColor = new Color(0.5f, 0.5f, 0.5f, 0.25f);

		public override string DisplayName => "Movement/Movement-Stop";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			brain.AIControl.LookAtTargetOnArrival = LookAtTarget;
			switch (task)
			{
			case MoveType.MoveToCurrentTarget:
				if ((bool)brain.AIControl.Target)
				{
					brain.AIControl.SetTarget(brain.AIControl.Target, move: true);
					brain.AIControl.UpdateDestinationPosition = true;
				}
				else
				{
					Debug.LogWarning("The Animal does not have a current Target", this);
				}
				break;
			case MoveType.MoveToNextTarget:
				brain.AIControl.MovetoNextTarget();
				break;
			case MoveType.Stop:
				brain.AIControl.Stop();
				brain.AIControl.UpdateDestinationPosition = false;
				brain.TaskDone(index);
				break;
			case MoveType.LockAnimalMovement:
				brain.Animal.LockMovement = true;
				brain.TaskDone(index);
				break;
			case MoveType.RotateInPlace:
				brain.AIControl.RemainingDistance = 0f;
				brain.AIControl.DestinationPosition = brain.AIControl.Transform.position;
				brain.AIControl.LookAtTargetOnArrival = true;
				brain.AIControl.UpdateDestinationPosition = false;
				brain.AIControl.HasArrived = true;
				brain.AIControl.Stop();
				brain.TaskDone(index);
				break;
			case MoveType.Flee:
				brain.AIControl.CurrentSlowingDistance = slowingDistance;
				Flee(brain, index);
				break;
			case MoveType.KeepDistance:
				brain.AIControl.CurrentSlowingDistance = slowingDistance;
				KeepDistance(brain, index);
				break;
			case MoveType.CircleAround:
				brain.AIControl.CurrentSlowingDistance = slowingDistance;
				CalculateClosestCirclePoint(brain, index);
				break;
			case MoveType.MoveToLastKnownDestination:
			{
				Vector3 destinationPosition = brain.AIControl.DestinationPosition;
				Debug.DrawRay(brain.Position, Vector3.up, Color.white, 1f);
				brain.AIControl.DestinationPosition = Vector3.zero;
				brain.AIControl.SetDestination(destinationPosition, move: true);
				brain.AIControl.UpdateDestinationPosition = false;
				brain.AIControl.CurrentSlowingDistance = slowingDistance;
				break;
			}
			}
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			switch (task)
			{
			case MoveType.MoveToCurrentTarget:
				StopOnArrived(brain, index);
				break;
			case MoveType.MoveToNextTarget:
				StopOnArrived(brain, index);
				break;
			case MoveType.Flee:
				Flee(brain, index);
				break;
			case MoveType.KeepDistance:
				KeepDistance(brain, index);
				break;
			case MoveType.CircleAround:
				CircleAround(brain, index);
				break;
			case MoveType.MoveToLastKnownDestination:
				if (brain.AIControl.HasArrived)
				{
					brain.AIControl.Stop();
					brain.TaskDone(index);
				}
				break;
			case MoveType.LockAnimalMovement:
			case MoveType.Stop:
			case MoveType.RotateInPlace:
				break;
			}
		}

		private void StopOnArrived(MAnimalBrain brain, int index)
		{
			if (brain.AIControl.HasArrived)
			{
				if (StopOnArrive)
				{
					brain.AIControl.Stop();
				}
				brain.AIControl.LookAtTargetOnArrival = LookAtTarget;
				brain.TaskDone(index);
			}
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			if (task == MoveType.LockAnimalMovement)
			{
				brain.Animal.LockMovement = false;
			}
		}

		public override void OnTargetArrived(MAnimalBrain brain, Transform target, int index)
		{
			switch (task)
			{
			case MoveType.MoveToCurrentTarget:
				StopOnArrived(brain, index);
				break;
			case MoveType.MoveToNextTarget:
				StopOnArrived(brain, index);
				break;
			case MoveType.LockAnimalMovement:
				brain.TaskDone(index);
				break;
			case MoveType.Stop:
				brain.TaskDone(index);
				break;
			case MoveType.RotateInPlace:
				brain.TaskDone(index);
				break;
			case MoveType.MoveToLastKnownDestination:
				brain.AIControl.Stop();
				brain.TaskDone(index);
				break;
			case MoveType.Flee:
			case MoveType.CircleAround:
			case MoveType.KeepDistance:
				break;
			}
		}

		private void CalculateClosestCirclePoint(MAnimalBrain brain, int index)
		{
			float num = 360f / (float)arcsCount;
			int num2 = ((direction == CircleDirection.Right) ? 1 : (-1));
			Quaternion quaternion = Quaternion.Euler(0f, (float)num2 * num, 0f);
			Vector3 vector = Vector3.forward;
			Vector3 positionTarget = Vector3.zero;
			float num3 = float.MaxValue;
			int intValue = 0;
			for (int i = 0; i < arcsCount; i++)
			{
				Vector3 vector2 = brain.Target.position + vector.normalized * distance;
				float num4 = Vector3.Distance(vector2, brain.transform.position);
				if (num3 > num4)
				{
					num3 = num4;
					intValue = i;
					positionTarget = vector2;
				}
				vector = quaternion * vector;
			}
			brain.AIControl.UpdateDestinationPosition = false;
			brain.AIControl.StoppingDistance = stoppingDistance;
			brain.TasksVars[index].intValue = intValue;
			brain.TasksVars[index].boolValue = true;
			brain.AIControl.UpdateDestinationPosition = false;
			brain.AIControl.SetDestination(positionTarget, move: true);
			brain.AIControl.HasArrived = false;
		}

		private void CircleAround(MAnimalBrain brain, int index)
		{
			if (brain.AIControl.HasArrived)
			{
				brain.TasksVars[index].intValue++;
				brain.TasksVars[index].intValue = brain.TasksVars[index].intValue % arcsCount;
				brain.TasksVars[index].boolValue = true;
			}
			if (brain.TasksVars[index].boolValue || brain.AIControl.TargetIsMoving)
			{
				int intValue = brain.TasksVars[index].intValue;
				float num = 360f / (float)arcsCount;
				int num2 = ((direction == CircleDirection.Right) ? 1 : (-1));
				Quaternion quaternion = Quaternion.Euler(0f, (float)num2 * num * (float)intValue, 0f);
				Vector3 forward = Vector3.forward;
				forward = quaternion * forward;
				Vector3 vector = brain.Target.position + forward.normalized * distance;
				Debug.DrawRay(vector, Vector3.up, Color.green, UpdateInterval);
				brain.AIControl.UpdateDestinationPosition = false;
				brain.AIControl.SetDestination(vector, move: true);
				brain.TasksVars[index].boolValue = false;
			}
		}

		private void KeepDistance(MAnimalBrain brain, int index)
		{
			if (!brain.Target)
			{
				return;
			}
			brain.AIControl.UpdateDestinationPosition = true;
			brain.AIControl.StoppingDistance = stoppingDistance;
			brain.AIControl.LookAtTargetOnArrival = false;
			Vector3 vector = brain.Animal.transform.position;
			Vector3 vector2 = vector - brain.Target.position;
			float num = (float)distanceThreshold * 0.5f;
			float magnitude = vector2.magnitude;
			float num2 = (float)distance * brain.Animal.ScaleFactor;
			if (magnitude < num2 - (float)distanceThreshold)
			{
				float distanceDiff = num2 - magnitude;
				vector = CalculateDistance(brain, index, vector2, distanceDiff, num);
			}
			else if (magnitude > num2 + (float)distanceThreshold)
			{
				float distanceDiff2 = magnitude - num2;
				vector = CalculateDistance(brain, index, -vector2, distanceDiff2, 0f - num);
			}
			else
			{
				if (!brain.AIControl.HasArrived)
				{
					brain.AIControl.Stop();
				}
				brain.AIControl.HasArrived = true;
				brain.AIControl.LookAtTargetOnArrival = LookAtTarget;
				brain.AIControl.StoppingDistance = num2 + (float)distanceThreshold;
				brain.AIControl.RemainingDistance = 0f;
			}
			if (brain.debug)
			{
				Debug.DrawRay(vector, brain.transform.up, Color.cyan, UpdateInterval);
			}
		}

		private Vector3 CalculateDistance(MAnimalBrain brain, int index, Vector3 DirFromTarget, float DistanceDiff, float halThreshold)
		{
			Vector3 vector = brain.transform.position + DirFromTarget.normalized * (DistanceDiff + halThreshold);
			brain.AIControl.UpdateDestinationPosition = false;
			brain.AIControl.StoppingDistance = stoppingDistance;
			brain.AIControl.SetDestination(vector, move: true);
			return vector;
		}

		private void Flee(MAnimalBrain brain, int index)
		{
			if (!brain.Target)
			{
				return;
			}
			brain.AIControl.UpdateDestinationPosition = false;
			Vector3 position = brain.Animal.transform.position;
			float num = Vector3.Distance(brain.Animal.transform.position, brain.Position);
			Vector3 vector = position - brain.Target.position;
			float magnitude = vector.magnitude;
			float num2 = (float)distance * brain.Animal.ScaleFactor;
			if (magnitude < num2)
			{
				Vector3 vector2 = brain.Target.position + vector.normalized * (num2 + num * 2f);
				brain.AIControl.StoppingDistance = stoppingDistance;
				Debug.DrawRay(vector2, Vector3.up * 3f, Color.blue, 2f);
				if (Vector3.Distance(position, vector2) > (float)stoppingDistance)
				{
					brain.AIControl.UpdateDestinationPosition = false;
					brain.AIControl.SetDestination(vector2, move: true);
					if (brain.debug)
					{
						Debug.DrawRay(vector2, brain.transform.up, Color.blue, 2f);
					}
				}
			}
			else
			{
				brain.AIControl.Stop();
				brain.AIControl.LookAtTargetOnArrival = LookAtTarget;
				if (!FleeForever)
				{
					brain.TaskDone(index);
				}
			}
		}
	}
}
