using System.Text;
using UnityEngine;

public static class CommandTree
{
	private static CommandNode rootNode;

	private static CommandNode queuedMatchNode;

	public static bool HasMatch
	{
		get
		{
			return queuedMatchNode != null;
		}
	}

	public static void Reset()
	{
		rootNode = null;
		queuedMatchNode = null;
	}

	public static void AddCommand(string commandText, CommandTypeEnum commandType, object data)
	{
		AddCommand(new CommandDefinition(commandText, string.Empty), commandType, data);
	}

	public static void AddCommand(CommandDefinition commandDefinition, CommandTypeEnum commandType, object data)
	{
		AddCommand(commandDefinition, commandType, data, null);
	}

	public static void AddCommand(CommandDefinition commandDefinition, CommandTypeEnum commandType, object data, MultiObjectProcessVerification moProcessVerificationMethod)
	{
		if (rootNode == null)
		{
			rootNode = new CommandNode(null);
		}
		if (commandType == CommandTypeEnum.MultiObjectCommand)
		{
			CommandNode commandNode = FindExactMatch(commandDefinition.CommandName);
			if (commandNode != null)
			{
				commandNode.AddData(data);
				return;
			}
		}
		rootNode.AddCommand(commandDefinition, commandType, data, moProcessVerificationMethod);
	}

	public static bool FindBestMatch(string partialString, out bool exactMatch, out CommandNode foundNode)
	{
		exactMatch = false;
		foundNode = null;
		if (rootNode != null)
		{
			if (rootNode.FindMatch(partialString, out exactMatch, out foundNode))
			{
				if (exactMatch && foundNode.CommandType == CommandTypeEnum.AliasCommand)
				{
					CommandNode commandNode = foundNode;
					CommandNode foundNode2 = null;
					bool exactMatch2 = false;
					bool flag = false;
					int num = 0;
					do
					{
						flag = rootNode.FindMatch(commandNode.Data.ToString(), out exactMatch2, out foundNode2);
						if (flag)
						{
							foundNode = foundNode2;
							commandNode = foundNode;
							exactMatch = exactMatch2;
						}
						num++;
					}
					while (flag && num < 100);
				}
				queuedMatchNode = foundNode;
				return true;
			}
		}
		else
		{
			Debug.LogWarning("Tree has not been built");
		}
		queuedMatchNode = null;
		return false;
	}

	public static CommandNode FindExactMatch(string fullCommand)
	{
		if (rootNode != null)
		{
			CommandNode foundNode = null;
			bool exactMatch = false;
			if (rootNode.FindMatch(fullCommand, out exactMatch, out foundNode) && exactMatch)
			{
				return foundNode;
			}
		}
		else
		{
			Debug.LogWarning("Tree has not been built");
		}
		return null;
	}

	public static bool TestAndUseQueuedMatch(string partialString, out CommandNode queuedCommand)
	{
		queuedCommand = queuedMatchNode;
		ResetQueuedMatch();
		if (queuedCommand != null && queuedCommand.CommandText.StartsWith(partialString))
		{
			return true;
		}
		return false;
	}

	public static void ResetQueuedMatch()
	{
		queuedMatchNode = null;
	}

	public static void WriteTree()
	{
		if (rootNode != null)
		{
			StringBuilder sb = new StringBuilder();
			rootNode.WriteNode(0, ref sb);
			GameplayManager.ShowConsoleMessage(sb.ToString(), ConsoleMessageType.Info);
		}
		else
		{
			GameplayManager.ShowConsoleMessage("Tree has not been built", ConsoleMessageType.Warning);
		}
	}
}
