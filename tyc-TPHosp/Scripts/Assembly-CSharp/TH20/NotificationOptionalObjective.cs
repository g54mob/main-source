using System;

namespace TH20
{
	public class NotificationOptionalObjective : NotificationMessage
	{
		private readonly ObjectiveDefinition _objectiveDefinition;

		private readonly LevelScriptManager _levelScriptManager;

		private readonly string _objectiveName;

		public NotificationOptionalObjective(NotificationMessages.Definition definition, string objectiveName, LevelScriptManager levelScriptManager, ObjectiveDefinition objectiveDefinition, Level level)
			: base(definition, level)
		{
			_levelScriptManager = levelScriptManager;
			_objectiveName = objectiveName;
			_objectiveDefinition = objectiveDefinition;
		}

		protected override void RegisterEvents()
		{
			_delegate = OnDecision;
		}

		private void OnDecision(int choice)
		{
			if (choice == 0)
			{
				_levelScriptManager.CreateObjective($"{_objectiveName}_{Guid.NewGuid()}", _objectiveDefinition, isVisible: true, isDiscovered: true, isReplayable: false, startImmediately: true);
			}
		}

		public override string GetMessageText()
		{
			return string.Concat(base.Definition.GetTextString() + "\n\n", _objectiveDefinition.GetDescriptionString(null, _objectiveDefinition.CompletionRewards));
		}

		public override Character GetCharacter()
		{
			return null;
		}
	}
}
