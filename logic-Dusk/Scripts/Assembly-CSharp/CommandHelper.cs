using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using UnityEngine;

public static class CommandHelper
{
	private static Dictionary<string, List<CommandDefinition>> _commandLookup;

	private static Dictionary<string, string> aliasCommandDict = new Dictionary<string, string>();

	private static List<CommandDefinition> _aliasCommands = new List<CommandDefinition>();

	private static Dictionary<string, string> secretCommands = null;

	public static void Initialize()
	{
		if (_commandLookup == null)
		{
			_commandLookup = new Dictionary<string, List<CommandDefinition>>();
			LoadCommandDefinitionLibrary();
			LoadAliasFile();
		}
	}

	public static void ReloadAliasFile(bool forceRecreateFile)
	{
		aliasCommandDict.Clear();
		CommandTree.Reset();
		_aliasCommands.Clear();
		LoadAliasFile(forceRecreateFile);
	}

	public static List<CommandDefinition> GetCommands(string commandGroup)
	{
		if (_commandLookup == null)
		{
			Initialize();
		}
		if (_commandLookup.ContainsKey(commandGroup))
		{
			return _commandLookup[commandGroup];
		}
		Debug.Log("GetCommands has no definitions for: " + commandGroup);
		return new List<CommandDefinition>();
	}

	public static List<CommandDefinition> GetAliasCommands()
	{
		Initialize();
		return _aliasCommands;
	}

	public static string TestAliasCommand(string commandText)
	{
		if (commandText.CompareTo("cat") <= 0)
		{
			Debug.Log("Meow");
		}
		else
		{
			Debug.Log("Woof");
		}
		return string.Empty;
	}

	public static bool DoesAliasCommandExist(string commandName)
	{
		if (aliasCommandDict != null && aliasCommandDict.ContainsKey(commandName))
		{
			return true;
		}
		return false;
	}

	private static void LoadCommandDefinitionLibrary()
	{
		TextAsset textAsset = (TextAsset)Resources.Load("Data/CommandDefinitions");
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(textAsset.text);
		XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//CommandDefinitions/CommandContext");
		foreach (XmlNode item in xmlNodeList)
		{
			List<CommandDefinition> list = new List<CommandDefinition>();
			_commandLookup.Add(item.Attributes["commandGroup"].Value, list);
			foreach (XmlNode childNode in item.ChildNodes)
			{
				CommandDefinition commandDefinitionFromXml = GetCommandDefinitionFromXml(childNode);
				if (commandDefinitionFromXml != null)
				{
					list.Add(commandDefinitionFromXml);
				}
			}
		}
	}

	private static void LoadAliasFile()
	{
		LoadAliasFile(false);
	}

	private static void LoadAliasFile(bool forceRecreateFile)
	{
		if (File.Exists(GameFileHelper.AliasFullPath()))
		{
			if (forceRecreateFile)
			{
				try
				{
					File.Delete(GameFileHelper.AliasFullPath());
				}
				catch (Exception ex)
				{
					Debug.LogError(string.Format("Filed to delete file!  Exception: {0}", ex.Message));
					return;
				}
				LoadAliasFile();
				return;
			}
			string[] array = File.ReadAllLines(GameFileHelper.AliasFullPath());
			if (array.Length > 0)
			{
				char[] separator = new char[1] { '=' };
				string[] array2 = array;
				foreach (string text in array2)
				{
					string[] array3 = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
					if (array3.Length != 2)
					{
						Debug.Log(string.Format("Could not parse line '{0}'.  Invalid format.  Ex: command_name=command_text", text));
					}
					else if (!aliasCommandDict.ContainsKey(array3[0]))
					{
						CommandTree.AddCommand(array3[0], CommandTypeEnum.AliasCommand, array3[1]);
						aliasCommandDict.Add(array3[0], array3[1]);
						CommandDefinition item = new CommandDefinition(array3[0], array3[1]);
						_aliasCommands.Add(item);
					}
					else
					{
						Debug.Log(string.Format("Multiple entries found for {0}.  Ignoring all but the first entry.", array3[0]));
					}
				}
			}
			else
			{
				Debug.Log("No lines found in alias file");
			}
			return;
		}
		Debug.Log(string.Format("Alias file not found: {0}", GameFileHelper.AliasFullPath()));
		if (!forceRecreateFile && 1 == 0)
		{
			return;
		}
		FileStream fileStream = null;
		Debug.Log("'ALIAS_IFMISSING_CREATEFROM_RESOURCE' enabled");
		try
		{
			fileStream = File.Create(GameFileHelper.AliasFullPath());
		}
		catch (Exception ex2)
		{
			Debug.LogError(string.Format("Filed to create file!  Exception: {0}", ex2.Message));
			return;
		}
		TextAsset textAsset = (TextAsset)Resources.Load("Data/alias");
		if (textAsset == null)
		{
			Debug.LogWarning(string.Format("File didn't exist in /Resources/Data/: 'alias.txt'"));
			try
			{
				fileStream.Close();
				return;
			}
			catch (Exception)
			{
				return;
			}
		}
		try
		{
			byte[] bytes = Encoding.ASCII.GetBytes(Environment.NewLine);
			string[] array4 = textAsset.text.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
			string[] array5 = array4;
			foreach (string s in array5)
			{
				byte[] bytes2 = Encoding.UTF8.GetBytes(s);
				int count = bytes2.Length;
				fileStream.Write(bytes2, 0, count);
				fileStream.Write(bytes, 0, bytes.Length);
			}
		}
		catch (Exception ex4)
		{
			Debug.LogError(string.Format("Error while writing file!  Exception: {0}", ex4.Message));
			return;
		}
		finally
		{
			try
			{
				fileStream.Close();
			}
			catch (Exception)
			{
			}
		}
		LoadAliasFile();
		Debug.Log("Successfully created and raloaded the alias file on your system.");
	}

	public static void SyncAliasFile()
	{
		TextAsset textAsset = (TextAsset)Resources.Load("Data/alias");
		try
		{
			DataFile dataFile = new DataFile();
			dataFile.InitSettingInstance(GameFileHelper.AliasFullPath());
			byte[] bytes = Encoding.ASCII.GetBytes(Environment.NewLine);
			string[] array = textAsset.text.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
			string[] array2 = array;
			foreach (string s in array2)
			{
				byte[] bytes2 = Encoding.UTF8.GetBytes(s);
				int num = bytes2.Length;
				string text = Encoding.UTF8.GetString(bytes2);
				string[] array3 = text.Split(new char[1] { '=' }, StringSplitOptions.RemoveEmptyEntries);
				if (array3.Length == 2)
				{
					dataFile.SaveSetting(array3[0], array3[1]);
				}
			}
			GameSaveFile.Save("ALIAS_VER", 1);
			ReloadAliasFile(false);
			LoadAliasFile();
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Format("Error while writing file!  Exception: {0}", ex.Message));
		}
	}

	public static string GetSecretCommandResults(string command)
	{
		if (secretCommands == null)
		{
			LoadSecretCommands();
		}
		string key = command.ToLower();
		if (secretCommands.ContainsKey(key))
		{
			return secretCommands[key];
		}
		return string.Empty;
	}

	private static void LoadSecretCommands()
	{
		if (secretCommands == null)
		{
			secretCommands = new Dictionary<string, string>();
		}
		TextAsset textAsset = (TextAsset)Resources.Load("Data/secret_commands");
		string[] array = textAsset.text.Split('\r');
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			string[] array2 = array[i].Split(new char[1] { ',' }, 2);
			if (i >= array.Length)
			{
				continue;
			}
			string text = array2[0].ToLower();
			text = text.Replace("\r", string.Empty).Replace("\n", string.Empty);
			if (!secretCommands.ContainsKey(text))
			{
				string text2 = array2[1];
				if (text2.StartsWith("\""))
				{
					text2 = text2.Substring(1);
				}
				if (text2.EndsWith("\""))
				{
					text2 = text2.Substring(0, text2.Length - 1);
				}
				secretCommands.Add(text, text2);
			}
		}
	}

	private static CommandDefinition GetCommandDefinitionFromXml(XmlNode node)
	{
		if (node.Attributes["name"] == null)
		{
			return null;
		}
		string targetNumberString = ConsoleCommandTarget.Undefined.ToString();
		if (node.Attributes["commandTarget"] != null && !string.IsNullOrEmpty(node.Attributes["commandTarget"].Value))
		{
			targetNumberString = node.Attributes["commandTarget"].Value;
		}
		CommandDefinition commandDefinition = new CommandDefinition(node.Attributes["name"].Value, (node.Attributes["description"] == null) ? string.Empty : node.Attributes["description"].Value, (node.Attributes["example"] == null) ? string.Empty : node.Attributes["example"].Value, targetNumberString, (node.Attributes["devCmd"] == null) ? "false" : node.Attributes["devCmd"].Value, (node.Attributes["internal"] == null) ? "false" : node.Attributes["internal"].Value, (node.Attributes["shortcut"] == null) ? "false" : node.Attributes["shortcut"].Value, (node.Attributes["tag"] == null) ? string.Empty : node.Attributes["tag"].Value, (node.Attributes["isAdvanced"] == null) ? string.Empty : node.Attributes["isAdvanced"].Value, (node.Attributes["hideFromManual"] == null) ? string.Empty : node.Attributes["hideFromManual"].Value, (node.Attributes["helpOnly"] == null) ? "false" : node.Attributes["helpOnly"].Value, (node.Attributes["hideFromAutoComplete"] == null) ? "false" : node.Attributes["hideFromAutoComplete"].Value);
		List<ConsoleMessage> list = new List<ConsoleMessage>();
		if (node.ChildNodes != null && node.ChildNodes.Count > 0)
		{
			foreach (XmlNode childNode in node.ChildNodes)
			{
				if (childNode.Name != "CommandUpgradeMod")
				{
					ConsoleMessage consoleMessageFromXml = GetConsoleMessageFromXml(childNode);
					if (consoleMessageFromXml != null)
					{
						list.Add(consoleMessageFromXml);
					}
					continue;
				}
				if (commandDefinition.ModList == null)
				{
					commandDefinition.ModList = new List<CommandMod>();
				}
				CommandMod item = new CommandMod(childNode.Attributes["name"].Value, (childNode.Attributes["description"] == null) ? string.Empty : childNode.Attributes["description"].Value, (childNode.Attributes["example"] == null) ? string.Empty : childNode.Attributes["example"].Value, (childNode.Attributes["symbol"] == null) ? string.Empty : childNode.Attributes["symbol"].Value);
				commandDefinition.ModList.Add(item);
			}
		}
		commandDefinition.DetailedDescription.AddRange(list);
		return commandDefinition;
	}

	private static ConsoleMessage GetConsoleMessageFromXml(XmlNode node)
	{
		if (node.Attributes["message"] == null)
		{
			return null;
		}
		string typeString = ConsoleMessageType.Info.ToString();
		if (node.Attributes["type"] != null && !string.IsNullOrEmpty(node.Attributes["type"].Value))
		{
			typeString = node.Attributes["type"].Value;
		}
		string formatString = ConsoleMessageFormat.Normal.ToString();
		if (node.Attributes["format"] != null && !string.IsNullOrEmpty(node.Attributes["format"].Value))
		{
			formatString = node.Attributes["format"].Value;
		}
		return new ConsoleMessage(node.Attributes["message"].Value, typeString, formatString);
	}
}
