public class ConstructionCommandsModel : CommandManagerModel<ConstructionCommandFeedback>
{
	public const string CommandExecutedEvent = "ConstructionCommandsModel.CommandExecutedEvent";

	public const string WarningMessageEvent = "ConstructionCommandsModel.WarningMessageEvent";

	public override ConstructionCommandFeedback ExecuteNewCommand(Command<ConstructionCommandFeedback> command)
	{
		ConstructionCommandFeedback constructionCommandFeedback = command.Execute();
		switch (constructionCommandFeedback)
		{
		case ConstructionCommandFeedback.Executed:
			allExecutedCommands.Add(command);
			allRevertedCommands.Clear();
			NotifyChange("ConstructionCommandsModel.CommandExecutedEvent", allExecutedCommands.Count, allRevertedCommands.Count);
			break;
		case ConstructionCommandFeedback.MoreThanOneBrain:
		{
			string text = LanguagesManager.Instance.GetText("warning.text.block.onecompanion", "Only one companion block can be placed!");
			NotifyChange("ConstructionCommandsModel.WarningMessageEvent", text);
			break;
		}
		}
		return constructionCommandFeedback;
	}
}
