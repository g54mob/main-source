using System;
using MoonSharp.Interpreter;

[MoonSharpUserData]
public class ModQuest
{
	public void SetQuestComplete(string QuestID, bool DoCeremony = false)
	{
		Quest.ID result;
		if (!Enum.TryParse<Quest.ID>(QuestID, out result))
		{
			string descriptionOverride = "Error: ModQuest.SetQuestComplete '" + QuestID + "' - Item not found";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
		}
		else
		{
			Quest quest = QuestManager.Instance.GetQuest(result);
			QuestManager.Instance.CheatCompleteQuest(quest, DoCeremony);
		}
	}

	public void SetAllQuestsComplete()
	{
		QuestManager.Instance.CompleteAll();
	}

	public bool IsObjectTypeUnlocked(string ObjectTypeString)
	{
		ObjectType result = ObjectType.Nothing;
		if (!Enum.TryParse<ObjectType>(ObjectTypeString, out result))
		{
			result = ModManager.Instance.GetModObjectTypeFromName(ObjectTypeString);
		}
		if (result == ObjectType.Nothing)
		{
			string descriptionOverride = "Error: ModQuest.IsObjectTypeUnlocked '" + ObjectTypeString + "' - Object Type Not Recognised";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return false;
		}
		return QuestManager.Instance.GetIsObjectLockedAny(result);
	}
}
