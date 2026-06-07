using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Set Destination")]
	public class SetDestinationTask : MTask
	{
		public enum DestinationType
		{
			Transform = 0,
			GameObject = 1,
			RuntimeGameObjects = 2,
			Vector3 = 3,
			Name = 4
		}

		[Tooltip("Slow multiplier to set on the Destination")]
		public float SlowMultiplier;

		[Space]
		public DestinationType targetType;

		[RequiredField]
		public TransformVar TargetT;

		[RequiredField]
		public Vector3Var Destination;

		[RequiredField]
		public GameObjectVar TargetG;

		[RequiredField]
		public RuntimeGameObjects TargetRG;

		public RuntimeSetTypeGameObject rtype = RuntimeSetTypeGameObject.Random;

		public IntReference RTIndex = new IntReference();

		public StringReference RTName = new StringReference();

		[Tooltip("When a new target is assinged it also sets that the Animal should move to that target")]
		public bool MoveToTarget = true;

		public override string DisplayName => "Movement/Set Destination";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			brain.AIControl.ClearTarget();
			brain.AIControl.CurrentSlowingDistance = brain.AIControl.StoppingDistance * SlowMultiplier;
			switch (targetType)
			{
			case DestinationType.Transform:
				if (TargetT == null)
				{
					Debug.LogError("Set Destination Task is missing the Transform Hook", this);
					return;
				}
				brain.AIControl.SetDestination(TargetT.Value.position, MoveToTarget);
				break;
			case DestinationType.GameObject:
				if (TargetG == null)
				{
					Debug.LogError("Set Destination Task is missing the GameObject Hook", this);
					return;
				}
				brain.AIControl.SetDestination(TargetG.Value.transform.position, MoveToTarget);
				break;
			case DestinationType.RuntimeGameObjects:
			{
				if (TargetRG == null)
				{
					Debug.LogError("Set Destination Task is missing the RuntimeSet", this);
					return;
				}
				GameObject item = TargetRG.GetItem(rtype, RTIndex, RTName, brain.Animal.gameObject);
				if (item != null)
				{
					brain.AIControl.SetDestination(item.transform.position, MoveToTarget);
				}
				break;
			}
			case DestinationType.Vector3:
				if (Destination == null)
				{
					Debug.LogError("Set Destination Task is missing the Vector Scriptable Variable", this);
					return;
				}
				brain.AIControl.SetDestination(Destination.Value, MoveToTarget);
				break;
			case DestinationType.Name:
			{
				GameObject gameObject = GameObject.Find(RTName);
				if (gameObject != null)
				{
					brain.AIControl.SetDestination(gameObject.transform.position, MoveToTarget);
				}
				else
				{
					Debug.LogError("Using SetTarget.ByName() but there's no Gameobject with that name", this);
				}
				break;
			}
			}
			brain.TaskDone(index);
		}

		private void Reset()
		{
			Description = "Set a new Destination to the AI Animal Control, it uses Run time sets Transforms or GameObjects";
		}
	}
}
