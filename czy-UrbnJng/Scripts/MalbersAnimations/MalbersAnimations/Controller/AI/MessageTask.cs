using MalbersAnimations.Utilities;
using UnityEngine;

namespace MalbersAnimations.Controller.AI
{
	[CreateAssetMenu(menuName = "Malbers Animations/Pluggable AI/Tasks/Message Task", fileName = "new Message Task")]
	public class MessageTask : MTask
	{
		[Space]
		[Tooltip("Apply the Task to the Animal(Self) or the Target(Target)")]
		public Affected affect;

		[Tooltip("When you want to send the Message")]
		public ExecuteTask when;

		public bool UseSendMessage;

		public bool SendToChildren;

		[Tooltip("Send the message only when the AI is near the target. AI has Arrived")]
		public bool NearTarget = true;

		[Tooltip("The message will be send to the Root of the Hierarchy")]
		public bool SendToRoot = true;

		[NonReorderable]
		public MesssageItem[] messages;

		public override string DisplayName => "General/Send Message";

		public override void StartTask(MAnimalBrain brain, int index)
		{
			if (when == ExecuteTask.OnStart && (!NearTarget || (NearTarget && brain.AIControl.HasArrived)))
			{
				Execute_Task(brain);
				brain.TaskDone(index);
			}
		}

		public override void UpdateTask(MAnimalBrain brain, int index)
		{
			if (when == ExecuteTask.OnUpdate && (!NearTarget || (NearTarget && brain.AIControl.HasArrived)))
			{
				Execute_Task(brain);
			}
		}

		public override void ExitAIState(MAnimalBrain brain, int index)
		{
			if (when == ExecuteTask.OnExit && (!NearTarget || (NearTarget && brain.AIControl.HasArrived)))
			{
				Execute_Task(brain);
				brain.TaskDone(index);
			}
		}

		private void Execute_Task(MAnimalBrain brain)
		{
			if (affect == Affected.Self)
			{
				SendMessage(SendToRoot ? brain.Animal.transform : brain.transform);
			}
			else if (brain.Target != null)
			{
				SendMessage(SendToRoot ? brain.Target.FindObjectCore() : brain.Target);
			}
		}

		public virtual void SendMessage(Transform t)
		{
			IAnimatorListener[] array = ((!SendToChildren) ? t.GetComponents<IAnimatorListener>() : t.GetComponentsInChildren<IAnimatorListener>());
			MesssageItem[] array2 = messages;
			foreach (MesssageItem messsageItem in array2)
			{
				if (UseSendMessage)
				{
					messsageItem.DeliverMessage(t, SendToChildren);
					continue;
				}
				IAnimatorListener[] array3 = array;
				foreach (IAnimatorListener listener in array3)
				{
					messsageItem.DeliverAnimListener(listener);
				}
			}
		}

		private void Reset()
		{
			Description = "Send messages to the Root game Object of the Target or the Animal using the Brain";
		}
	}
}
