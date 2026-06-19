using BehaviorDesigner.Runtime.Tasks;
using FullInspector.Generated.SharedInstance;
using JetBrains.Annotations;

namespace TH20.BTA.Level
{
	[TaskCategory(" TH20/Level Script/Objectives")]
	[TaskName("Show Objective Notification")]
	[TaskIcon("Assets/Editor/BehaviorDesigner/Icons/ObjectiveIconOptional.png")]
	public class CreateObjectiveOptional : ExpiringLevelAction
	{
		[UsedImplicitly]
		public SharedInstance_TH20TH20_ObjectiveDefinition Objective;

		[UsedImplicitly]
		public string Name;

		[Tooltip("DEPRECATED - Please use a notification reference")]
		[UsedImplicitly]
		public NotificationMessages.Definition MessageDefinition;

		[UsedImplicitly]
		public SharedInstance_TH20TH20_NotificationMessagesDefinition MessageDefinitionInstance;

		public override TaskStatus OnUpdate()
		{
			if (!HasTaskExpired())
			{
				NotificationMessages.Definition definition = ((MessageDefinitionInstance != null) ? MessageDefinitionInstance.Instance : MessageDefinition);
				if (definition == null)
				{
					return TaskStatus.Failure;
				}
				if (Objective == null || Objective.Instance == null)
				{
					return TaskStatus.Failure;
				}
				if (!Objective.Instance.HasGoalBeenAchieved(base.Owner.Level))
				{
					NotificationOptionalObjective message = new NotificationOptionalObjective(definition, Name, base.Owner.Level.LevelScriptManager, Objective.Instance, base.Owner.Level);
					base.Owner.Level.Notifications.Send(message);
				}
			}
			return TaskStatus.Success;
		}
	}
}
