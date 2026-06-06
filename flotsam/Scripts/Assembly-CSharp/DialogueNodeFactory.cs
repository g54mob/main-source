using System;

public static class DialogueNodeFactory
{
	public static IDialogueNode GetNode<PropertiesType>(PropertiesType properties) where PropertiesType : DialogueNodeProperties
	{
		if (!(properties is DialogueNodeSentenceProperties properties2))
		{
			if (!(properties is DialogueNodePanelProperties properties3))
			{
				if (!(properties is DialogueNodeDialogPopUpProperties properties4))
				{
					if (!(properties is DialogueNodePlayerChoicesProperties properties5))
					{
						if (properties is DialogueNodeEmptyProperties properties6)
						{
							return new DialogueNodeEmpty(properties6);
						}
						throw new NotImplementedException($"Node properties of type {properties.GetType()} not supported!");
					}
					return new DialogueNodePlayerChoices(properties5);
				}
				return new DialogueNodeDialogPopUp(properties4);
			}
			return new DialogueNodePanel(properties3);
		}
		return new DialogueNodeSentence(properties2);
	}
}
