using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Set Target")]
	public class SetTargetTask : MTask
	{
		public enum TargetToFollow
		{
			Transform = 0,
			GameObject = 1,
			RuntimeGameObjects = 2,
			ClearTarget = 3,
			Name = 4
		}

		[Space]
		public TargetToFollow targetType;

		[RequiredField]
		public TransformVar TargetT;

		[RequiredField]
		public GameObjectVar TargetG;

		[RequiredField]
		public RuntimeGameObjects TargetRG;

		public RuntimeSetTypeGameObject rtype = RuntimeSetTypeGameObject.Random;

		public IntReference RTIndex = new IntReference();

		public StringReference RTName = new StringReference();

		[Tooltip("When a new target is assinged it also sets that the Animal should move to that target")]
		public bool MoveToTarget = true;

		public override string DisplayName => "Movement/Set Target";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			if (MoveToTarget)
			{
				brain.AIControl.UpdateDestinationPosition = true;
			}
			else if (brain.AIControl.IsMoving)
			{
				brain.AIControl.Stop();
			}
			switch (targetType)
			{
			case TargetToFollow.Transform:
				brain.AIControl.SetTarget(TargetT.Value, MoveToTarget);
				break;
			case TargetToFollow.GameObject:
				brain.AIControl.SetTarget(TargetG.Value.transform, MoveToTarget);
				break;
			case TargetToFollow.RuntimeGameObjects:
				if (TargetRG != null && !TargetRG.IsEmpty)
				{
					GameObject item = TargetRG.GetItem(rtype, RTIndex, RTName, brain.Animal.gameObject);
					if ((bool)item)
					{
						brain.AIControl.SetTarget(item.transform, MoveToTarget);
					}
				}
				break;
			case TargetToFollow.ClearTarget:
				brain.AIControl.ClearTarget();
				break;
			case TargetToFollow.Name:
			{
				GameObject gameObject = GameObject.Find(RTName);
				if (gameObject != null)
				{
					brain.AIControl.SetTarget(gameObject.transform, MoveToTarget);
				}
				else
				{
					Debug.Log("Using SetTarget.ByName() but there's no Gameobject with that name", this);
				}
				break;
			}
			}
			brain.TaskDone(index);
		}

		private void Reset()
		{
			Description = "Set a new Target to the AI Animal Control, it uses Run time sets Transforms or GameObjects";
		}
	}
}
