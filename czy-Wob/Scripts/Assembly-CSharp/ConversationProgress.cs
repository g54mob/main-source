using System.Collections.Generic;
using UnityEngine;

public class ConversationProgress : MonoBehaviour
{
	public List<ConversationTracker> conversationTrackers = new List<ConversationTracker>();

	private Dictionary<string, int> trackerDict = new Dictionary<string, int>();

	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
		for (int i = 0; i < conversationTrackers.Count; i++)
		{
			trackerDict[conversationTrackers[i].name] = i;
		}
	}

	public TextAsset GetMainConversation(string name)
	{
		return conversationTrackers[trackerDict[name]].GetMainConversation();
	}

	public TextAsset GetGoodbye(string name)
	{
		return conversationTrackers[trackerDict[name]].GetGoodbye();
	}

	public void AdvanceConversationIndex(string name)
	{
		ConversationTracker conversationTracker = conversationTrackers[trackerDict[name]];
		conversationTracker.conversationIndex++;
		conversationTrackers[trackerDict[name]] = conversationTracker;
	}

	public void AdvanceGoodbyeIndex(string name)
	{
		ConversationTracker conversationTracker = conversationTrackers[trackerDict[name]];
		conversationTracker.goodbyeIndex++;
		conversationTrackers[trackerDict[name]] = conversationTracker;
	}
}
