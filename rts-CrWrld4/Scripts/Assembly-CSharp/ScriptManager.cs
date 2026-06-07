using System.Collections.Generic;
using NBT.Tags;

public class ScriptManager
{
	private Dictionary<string, string> scriptsDictionary;

	private CPack cpack;

	public ScriptManager(CPack cpack)
	{
	}

	public string CompileAllScriptsFromEditor()
	{
		return null;
	}

	public void SyncScriptsToDisk()
	{
	}

	public string GetScript(string scriptName)
	{
		return null;
	}

	public List<string> GetScriptNames()
	{
		return null;
	}

	public void DeleteScript(string fullScriptName)
	{
	}

	public TagCompound WriteData()
	{
		return null;
	}

	public void ReadData(Tag tag)
	{
	}
}
