using System;
using NSEipix.Base;
using NSMedieval;
using NSMedieval.Controllers;
using NSMedieval.Objectives;

namespace Objectives
{
	public class ObjectiveController : MonoSingleton<ObjectiveController>
	{
		public event Action<ObjectiveInstance, bool> ObjectiveCompletedEvent;

		public event Action<ObjectiveInstance, ObjectiveTask, bool> ObjectiveTaskCompletedEvent;

		public event Action<ObjectiveInstance, ObjectiveTask, ObjectiveTaskRequirement, bool> ObjectiveTaskRequirementCompletedEvent;

		public event Action<ObjectiveInstance, ObjectiveTask, ObjectiveTaskRequirement> ObjectiveTaskRequirementChangedEvent;

		public void ObjectiveCompleted(ObjectiveInstance objectiveInstance, bool objectiveCompleted)
		{
			this.ObjectiveCompletedEvent?.Invoke(objectiveInstance, objectiveCompleted);
		}

		public void ObjectiveTaskCompleted(ObjectiveInstance objectiveInstance, ObjectiveTask task, bool taskCompleted)
		{
			if (LoadingController.IsLoadingComplete && taskCompleted)
			{
				string messageText = MonoSingleton<LocalizationController>.Instance.GetText("bbt_step_completed") + " " + task.GetNameText();
				MonoSingleton<BlackBarMessageController>.Instance.ShowBlackBarMessage(messageText);
			}
			this.ObjectiveTaskCompletedEvent?.Invoke(objectiveInstance, task, taskCompleted);
		}

		public void ObjectiveTaskRequirementCompleted(ObjectiveInstance objectiveInstance, ObjectiveTask task, ObjectiveTaskRequirement requirement, bool requirementCompleted)
		{
			this.ObjectiveTaskRequirementCompletedEvent?.Invoke(objectiveInstance, task, requirement, requirementCompleted);
		}

		public void ObjectiveTaskRequirementChanged(ObjectiveInstance objectiveInstance, ObjectiveTask task, ObjectiveTaskRequirement requirement)
		{
			this.ObjectiveTaskRequirementChangedEvent?.Invoke(objectiveInstance, task, requirement);
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			this.ObjectiveCompletedEvent = null;
			this.ObjectiveTaskCompletedEvent = null;
			this.ObjectiveTaskRequirementCompletedEvent = null;
			this.ObjectiveTaskRequirementChangedEvent = null;
		}
	}
}
