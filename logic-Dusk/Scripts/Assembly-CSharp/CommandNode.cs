using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CommandNode
{
	private static class LevenshteinDistance
	{
		public static int Compute(string s, string t)
		{
			int length = s.Length;
			int length2 = t.Length;
			int[,] array = new int[length + 1, length2 + 1];
			if (length == 0)
			{
				return length2;
			}
			if (length2 == 0)
			{
				return length;
			}
			int num = 0;
			while (num <= length)
			{
				array[num, 0] = num++;
			}
			int num2 = 0;
			while (num2 <= length2)
			{
				array[0, num2] = num2++;
			}
			for (int i = 1; i <= length; i++)
			{
				for (int j = 1; j <= length2; j++)
				{
					int num3 = ((t[j - 1] != s[i - 1]) ? 1 : 0);
					array[i, j] = Math.Min(Math.Min(array[i - 1, j] + 1, array[i, j - 1] + 1), array[i - 1, j - 1] + num3);
				}
			}
			return array[length, length2];
		}
	}

	private const int MAX_NODE_PER_LEAF = 4;

	private string _keyMin = string.Empty;

	private string _commandText = string.Empty;

	public CommandTypeEnum CommandType;

	public CommandNode[] childrenNodes;

	private CommandNode parentNode;

	public string KeyMin
	{
		get
		{
			return _keyMin;
		}
		private set
		{
			_keyMin = value;
			KeyLength = _keyMin.Length;
		}
	}

	public string KeyMax { get; private set; }

	public string CommandText
	{
		get
		{
			return _commandText;
		}
		set
		{
			_commandText = value;
			CommandLength = _commandText.Length;
		}
	}

	public int KeyLength { get; private set; }

	public int CommandLength { get; private set; }

	public object Data { get; private set; }

	public object FirstData
	{
		get
		{
			if (Data != null)
			{
				return ((List<object>)Data)[0];
			}
			return null;
		}
	}

	public CommandDefinition ObjectCommandDefinition { get; private set; }

	public bool IsRoot { get; private set; }

	public bool IsBuilt { get; private set; }

	public bool IsUsed { get; private set; }

	public bool IsCommandLeaf { get; private set; }

	public MultiObjectProcessVerification moProcessVerificationMethod { get; private set; }

	private CommandNode()
	{
	}

	public CommandNode(CommandNode parentNode)
	{
		this.parentNode = parentNode;
		KeyMin = string.Empty;
		KeyMax = string.Empty;
		IsBuilt = false;
		IsCommandLeaf = false;
		if (parentNode == null)
		{
			IsRoot = true;
			InitChildrenNodes();
			BuildChildrenNodes(string.Empty);
		}
	}

	public void WriteNode(int indentCount, ref StringBuilder sb)
	{
		if (!IsCommandLeaf)
		{
			sb.AppendLine(string.Format("{0}'{1}' to '{2}' ---", string.Empty.PadLeft(indentCount, '-'), KeyMin, KeyMax));
			if (childrenNodes == null)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (childrenNodes[i].IsUsed)
				{
					childrenNodes[i].WriteNode(indentCount + 2, ref sb);
				}
			}
		}
		else
		{
			sb.AppendLine(string.Format("{0}{1}( {2} )", string.Empty.PadLeft(indentCount, ' '), CommandText, CommandType));
		}
	}

	public void AddChildNode(CommandNode childNode)
	{
		for (int i = 0; i < 4; i++)
		{
			if (!childrenNodes[i].IsUsed)
			{
				childrenNodes[i].IsUsed = true;
				childNode.parentNode = this;
				childrenNodes[i] = childNode;
				return;
			}
		}
		CommandNode consolodatedNode = null;
		if (ConsolodateChildren(out consolodatedNode))
		{
			if (childNode.CommandText.StartsWith(consolodatedNode.KeyMin))
			{
				consolodatedNode.AddChildNode(childNode);
				return;
			}
			for (int j = 0; j < 4; j++)
			{
				if (!childrenNodes[j].IsUsed)
				{
					childrenNodes[j].IsUsed = true;
					childNode.parentNode = this;
					childrenNodes[j] = childNode;
					break;
				}
			}
		}
		else
		{
			Debug.LogError(string.Format("This early version of the tree just couldn't hand this many similarly named command.  Dropping the {0} node, including any children nodes", childNode.CommandText));
		}
	}

	public bool AddCommand(CommandDefinition commandDefinition, CommandTypeEnum commandType, object data, MultiObjectProcessVerification moProcessVerificationMethod)
	{
		bool hasFreeChild = false;
		CommandNode freeChild = null;
		if (!AddCommandToChild(commandDefinition, commandType, data, moProcessVerificationMethod, out hasFreeChild, out freeChild))
		{
			if (hasFreeChild)
			{
				freeChild.IsUsed = true;
				freeChild.MakeThisNodeCommandLeaf(commandDefinition, commandType, data, moProcessVerificationMethod);
				return true;
			}
			CommandNode consolodatedNode = null;
			if (!IsRoot && ConsolodateChildren(out consolodatedNode))
			{
				if (commandDefinition.CommandName.StartsWith(consolodatedNode.KeyMin))
				{
					consolodatedNode.AddCommand(commandDefinition, commandType, data, moProcessVerificationMethod);
				}
				else
				{
					AddCommand(commandDefinition, commandType, data, moProcessVerificationMethod);
				}
			}
			else
			{
				string partialCommand = commandDefinition.CommandName.Substring(0, KeyLength);
				IEnumerable<CommandNode> enumerable = childrenNodes.Where((CommandNode x) => x != null && x.IsCommandLeaf && x.CommandText.StartsWith(partialCommand));
				if (enumerable != null)
				{
					int num = int.MaxValue;
					CommandNode commandNode = null;
					foreach (CommandNode item in enumerable)
					{
						int num2 = LevenshteinDistance.Compute(commandDefinition.CommandName, item.CommandText);
						if (num2 < num)
						{
							num = num2;
							commandNode = item;
						}
					}
					if (commandNode != null)
					{
						commandNode.DowngradeCommandLeafToChild(partialCommand);
						commandNode.AddCommand(commandDefinition, commandType, data, moProcessVerificationMethod);
						return true;
					}
				}
				enumerable = childrenNodes.Where((CommandNode x) => x != null && x.IsCommandLeaf);
				if (enumerable != null)
				{
					int num3 = int.MaxValue;
					CommandNode commandNode2 = null;
					string text = string.Empty;
					foreach (CommandNode item2 in enumerable)
					{
						string text2 = item2.CommandText.Substring(0, KeyLength);
						int num4 = LevenshteinDistance.Compute(partialCommand, text2);
						if (num4 < num3)
						{
							num3 = num4;
							commandNode2 = item2;
							text = text2;
						}
					}
					if (commandNode2 != null)
					{
						string empty = string.Empty;
						string empty2 = string.Empty;
						if (partialCommand.CompareTo(text) <= 0)
						{
							empty = partialCommand;
							empty2 = text;
						}
						else
						{
							empty = text;
							empty2 = partialCommand;
						}
						commandNode2.DowngradeCommandLeafToChild(empty, empty2);
						commandNode2.AddCommand(commandDefinition, commandType, data, moProcessVerificationMethod);
						return true;
					}
				}
				Debug.LogError(string.Format("This early version of the tree just couldn't handel this many similarly named commands.  Ignoreing command: {0}", commandDefinition.CommandName));
				int num5 = 0;
				num5++;
			}
		}
		return true;
	}

	public void AddData(object data)
	{
		if (CommandType == CommandTypeEnum.MultiObjectCommand)
		{
			if (Data == null)
			{
				Data = new List<object>();
			}
			((List<object>)Data).Add(data);
		}
		else
		{
			Debug.LogWarning(string.Format("Can't use AddData() on a CommandNode of type '{0}'", CommandType));
		}
	}

	public int DataCount()
	{
		if (Data == null)
		{
			return 0;
		}
		if (CommandType == CommandTypeEnum.ObjectCommand)
		{
			return 1;
		}
		if (CommandType == CommandTypeEnum.MultiObjectCommand)
		{
			return ((List<object>)Data).Count;
		}
		return -1;
	}

	public void DowngradeCommandLeafToChild(string newKey)
	{
		DowngradeCommandLeafToChild(newKey, newKey);
	}

	public void DowngradeCommandLeafToChild(string newKeyMin, string newKeyMax)
	{
		InitChildrenNodes();
		AddCommand(ObjectCommandDefinition, CommandType, Data, moProcessVerificationMethod);
		CommandText = string.Empty;
		CommandType = CommandTypeEnum.None;
		ObjectCommandDefinition = null;
		Data = null;
		moProcessVerificationMethod = null;
		IsCommandLeaf = false;
		KeyMin = newKeyMin;
		KeyMax = newKeyMax + "zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz";
	}

	public bool FindMatch(string partialCommand, out bool exactMatch, out CommandNode foundNode)
	{
		exactMatch = false;
		foundNode = null;
		if (childrenNodes != null)
		{
			for (int i = 0; i < 4; i++)
			{
				CommandNode commandNode = childrenNodes[i];
				if (!commandNode.IsUsed || (commandNode.ObjectCommandDefinition != null && commandNode.ObjectCommandDefinition.DeveloperCommand && !GlobalSettings.cheatMode))
				{
					continue;
				}
				if (commandNode.IsCommandLeaf)
				{
					if (commandNode.CommandText.StartsWith(partialCommand))
					{
						foundNode = commandNode;
						if (commandNode.CommandLength == partialCommand.Length)
						{
							exactMatch = true;
						}
						return true;
					}
				}
				else if (partialCommand.CompareTo(commandNode.KeyMax) <= 0 && partialCommand.CompareTo(commandNode.KeyMin) >= 0)
				{
					if (commandNode.FindMatch(partialCommand, out exactMatch, out foundNode))
					{
						return true;
					}
				}
				else if (partialCommand.StartsWith(commandNode.KeyMin) && commandNode.FindMatch(partialCommand, out exactMatch, out foundNode))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool ConsolodateChildren(out CommandNode consolodatedNode)
	{
		if (parentNode == null)
		{
			int num = 0;
			num++;
		}
		int keyLength = parentNode.KeyLength;
		int num2 = 4;
		bool flag = false;
		consolodatedNode = null;
		for (int i = 0; i < num2 - 1; i++)
		{
			if (!childrenNodes[i].IsUsed || childrenNodes[i].CommandText.Length <= keyLength)
			{
				continue;
			}
			string text = childrenNodes[i].CommandText.Substring(0, keyLength + 1);
			for (int j = i + 1; j < num2; j++)
			{
				if (childrenNodes[j].IsUsed && childrenNodes[j].CommandText.Length >= text.Length && childrenNodes[j].CommandText.StartsWith(text))
				{
					if (childrenNodes[i].IsCommandLeaf)
					{
						childrenNodes[i].DowngradeCommandLeafToChild(text);
						consolodatedNode = childrenNodes[i];
					}
					CommandNode childNode = (CommandNode)childrenNodes[j].MemberwiseClone();
					childrenNodes[i].AddChildNode(childNode);
					childrenNodes[j] = new CommandNode(this);
					flag = true;
				}
			}
			if (flag)
			{
				return true;
			}
		}
		return false;
	}

	private bool AddCommandToChild(CommandDefinition commandDefinition, CommandTypeEnum commandType, object data, MultiObjectProcessVerification moProcessVerificationMethod, out bool hasFreeChild, out CommandNode freeChild)
	{
		hasFreeChild = false;
		freeChild = null;
		if (childrenNodes == null)
		{
			if (childrenNodes == null)
			{
				InitChildrenNodes();
			}
			hasFreeChild = true;
			freeChild = childrenNodes[0];
			return false;
		}
		string commandName = commandDefinition.CommandName;
		bool flag = false;
		bool flag2 = false;
		for (int i = 0; i < 4; i++)
		{
			if (childrenNodes[i].IsUsed)
			{
				if ((commandName.CompareTo(childrenNodes[i].KeyMax) <= 0 && commandName.CompareTo(childrenNodes[i].KeyMin) >= 0) || commandName.StartsWith(childrenNodes[i].KeyMax) || commandName.StartsWith(childrenNodes[i].KeyMin))
				{
					flag = true;
					return childrenNodes[i].AddCommand(commandDefinition, commandType, data, moProcessVerificationMethod);
				}
			}
			else if (!flag2)
			{
				flag2 = true;
				hasFreeChild = true;
				freeChild = childrenNodes[i];
			}
		}
		if (!flag && flag2)
		{
			return false;
		}
		return flag;
	}

	private void InitChildrenNodes()
	{
		childrenNodes = new CommandNode[4];
		for (int i = 0; i < 4; i++)
		{
			childrenNodes[i] = new CommandNode(this);
		}
	}

	private void BuildChildrenNodes(string startingKey)
	{
		BuildChildrenNodes(startingKey, 4, 0);
	}

	private void BuildChildrenNodes(string startingKey, int nodeCount, int startingNode)
	{
		int num = 26 / nodeCount;
		char c = '`';
		for (int i = 0; i < nodeCount; i++)
		{
			childrenNodes[startingNode + i] = new CommandNode(this);
			c = (char)(c + 1);
			childrenNodes[startingNode + i].KeyMin = startingKey + c;
			c = (char)(c + num);
			if (i == nodeCount - 1)
			{
				c = 'z';
			}
			childrenNodes[startingNode + i].KeyMax = startingKey + c + "zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz";
			childrenNodes[startingNode + i].IsUsed = true;
		}
		IsBuilt = true;
	}

	public void MakeThisNodeCommandLeaf(CommandDefinition commandDefinition, CommandTypeEnum commandType, object data, MultiObjectProcessVerification moProcessVerificationMethod)
	{
		IsCommandLeaf = true;
		CommandText = commandDefinition.CommandName;
		CommandType = commandType;
		ObjectCommandDefinition = commandDefinition;
		if (commandType == CommandTypeEnum.MultiObjectCommand)
		{
			AddData(data);
		}
		else
		{
			Data = data;
		}
		this.moProcessVerificationMethod = moProcessVerificationMethod;
		KeyMin = CommandText;
		KeyMax = CommandText;
	}

	public override string ToString()
	{
		return string.Format("[CommandNode: KeyMin={0}, KeyMax={1}, IsRoot={2}, IsUsed={3}, IsCommandLeaf={4}]", KeyMin, KeyMax, IsRoot, IsUsed, IsCommandLeaf);
	}
}
