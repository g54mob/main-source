using System.Collections.Generic;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	[AddComponentMenu("Character Controller Pro/Demo/Dynamic Platform/Node Based Platform")]
	public class NodeBasedPlatform : Platform
	{
		public enum SequenceType
		{
			Rewind = 0,
			Loop = 1,
			OneWay = 2
		}

		private enum ActionState
		{
			Idle = 0,
			Ready = 1,
			Waiting = 2,
			Working = 3,
			Done = 4
		}

		[SerializeField]
		private bool drawHandles = true;

		public bool move = true;

		public bool rotate;

		[SerializeField]
		private List<PlatformNode> actionsList = new List<PlatformNode>();

		public SequenceType sequenceType;

		public bool positiveSequenceDirection = true;

		[Range(0.1f, 50f)]
		[SerializeField]
		private float globalSpeedModifier = 1f;

		private ActionState actionState;

		private Vector3 targetPosition;

		private Vector3 targetRotation;

		private Vector3 startingPosition;

		private Vector3 startingRotation;

		private bool updateInitialPosition = true;

		private Vector3 initialPosition;

		private float time;

		private PlatformNode currentAction;

		private int currentActionIndex;

		public bool DrawHandles => drawHandles;

		public List<PlatformNode> ActionsList => actionsList;

		public bool UpdateInitialPosition => updateInitialPosition;

		public Vector3 InitialPosition => initialPosition;

		public int CurrentActionIndex => currentActionIndex;

		protected override void Awake()
		{
			base.Awake();
			updateInitialPosition = false;
			initialPosition = base.transform.position;
			actionState = ActionState.Ready;
			currentActionIndex = 0;
			currentAction = actionsList[0];
		}

		private void FixedUpdate()
		{
			float deltaTime = Time.deltaTime;
			switch (actionState)
			{
			case ActionState.Ready:
				SetTargets();
				actionState = ActionState.Working;
				break;
			case ActionState.Working:
				time += deltaTime * globalSpeedModifier;
				if (time >= currentAction.targetTime)
				{
					actionState = ActionState.Done;
					time = 0f;
					break;
				}
				if (move)
				{
					base.RigidbodyComponent.Move(CalculatePosition());
				}
				_ = base.RigidbodyComponent.Rotation;
				if (rotate)
				{
					base.RigidbodyComponent.Rotate(CalculateRotation());
				}
				break;
			case ActionState.Done:
				time = 0f;
				if (positiveSequenceDirection)
				{
					if (currentActionIndex != actionsList.Count - 1)
					{
						currentActionIndex++;
						actionState = ActionState.Ready;
					}
					else
					{
						switch (sequenceType)
						{
						case SequenceType.Loop:
							currentActionIndex = 0;
							actionState = ActionState.Ready;
							break;
						case SequenceType.Rewind:
							currentActionIndex--;
							positiveSequenceDirection = false;
							actionState = ActionState.Ready;
							break;
						case SequenceType.OneWay:
							actionState = ActionState.Idle;
							break;
						}
					}
				}
				else if (currentActionIndex != 0)
				{
					currentActionIndex--;
					actionState = ActionState.Ready;
				}
				else
				{
					switch (sequenceType)
					{
					case SequenceType.Loop:
						currentActionIndex = actionsList.Count - 1;
						actionState = ActionState.Ready;
						break;
					case SequenceType.Rewind:
						currentActionIndex++;
						positiveSequenceDirection = true;
						actionState = ActionState.Ready;
						break;
					case SequenceType.OneWay:
						actionState = ActionState.Idle;
						break;
					}
				}
				currentAction = actionsList[currentActionIndex];
				break;
			case ActionState.Idle:
			case ActionState.Waiting:
				break;
			}
		}

		public override string ToString()
		{
			return "Current Index = " + currentActionIndex + "\nState = " + actionState;
		}

		private void SetTargets()
		{
			startingPosition = base.transform.position;
			startingRotation = base.transform.eulerAngles;
			targetPosition = initialPosition + currentAction.position;
			targetRotation = currentAction.eulerAngles;
		}

		private Vector3 CalculatePosition()
		{
			float num = time / currentAction.targetTime;
			return Vector3.Lerp(startingPosition, targetPosition, currentAction.movementCurve.Evaluate(num));
		}

		private Quaternion CalculateRotation()
		{
			float num = time / currentAction.targetTime;
			float t = currentAction.rotationCurve.Evaluate(num);
			Vector3 euler = default(Vector3);
			euler.x = Mathf.LerpAngle(startingRotation.x, targetRotation.x, t);
			euler.y = Mathf.LerpAngle(startingRotation.y, targetRotation.y, t);
			euler.z = Mathf.LerpAngle(startingRotation.z, targetRotation.z, t);
			return Quaternion.Euler(euler);
		}
	}
}
