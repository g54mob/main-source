using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConversationTracker
{
	public bool debugMode;

	public TextAsset debugAsset;

	public string name;

	public int conversationIndex;

	public List<TextAsset> mainConversations = new List<TextAsset>();

	public int goodbyeIndex;

	public List<TextAsset> goodbyes = new List<TextAsset>();

	public TextAsset GetMainConversation()
	{
		if (debugMode)
		{
			return debugAsset;
		}
		return mainConversations[conversationIndex];
	}

	public TextAsset GetGoodbye()
	{
		if (debugMode)
		{
			return debugAsset;
		}
		return goodbyes[goodbyeIndex];
	}
}
