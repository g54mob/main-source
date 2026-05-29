using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class WorkerScriptManager : MonoBehaviour
{
	public static WorkerScriptManager Instance;

	[HideInInspector]
	public List<StoredScript> m_Scripts;

	public string m_BotBreakName;

	private List<Shout> m_CurrentShouts;

	private List<Shout> m_NewShouts;

	private Dictionary<string, List<RegisteredPhrase>> m_RegisteredPhrases;

	private void Awake()
	{
		Instance = this;
		m_Scripts = new List<StoredScript>();
		m_CurrentShouts = new List<Shout>();
		m_NewShouts = new List<Shout>();
		m_RegisteredPhrases = new Dictionary<string, List<RegisteredPhrase>>();
	}

	public StoredScript AddScript(string Name, HighInstructionList OldInstructions, ObjectType Head)
	{
		StoredScript storedScript = new StoredScript(new HighInstructionList(OldInstructions), Name, Head);
		m_Scripts.Add(storedScript);
		return storedScript;
	}

	public void RemoveScript(StoredScript NewScript)
	{
		if (m_Scripts.Contains(NewScript))
		{
			m_Scripts.Remove(NewScript);
		}
	}

	public HighInstructionList GetScript(string Name, bool ErrorCheck = true)
	{
		foreach (StoredScript script in m_Scripts)
		{
			if (script.m_Name == Name)
			{
				return script.m_Instructions;
			}
		}
		if (ErrorCheck)
		{
			ErrorMessage.LogError("Couldn't find script " + Name);
		}
		return null;
	}

	public void Save(JSONNode Node)
	{
		JSONArray jSONArray = (JSONArray)(Node["ScriptArray"] = new JSONArray());
		int num = 0;
		foreach (StoredScript script in m_Scripts)
		{
			jSONArray[num] = new JSONObject();
			JSONUtils.Set(jSONArray[num], "Name", script.m_Name);
			JSONUtils.Set(jSONArray[num], "Head", script.m_Head.ToString());
			script.m_Instructions.Save(jSONArray[num]);
			num++;
		}
	}

	public void Load(JSONNode Node)
	{
		JSONArray asArray = Node["ScriptArray"].AsArray;
		for (int i = 0; i < asArray.Count; i++)
		{
			HighInstructionList highInstructionList = new HighInstructionList();
			string asString = JSONUtils.GetAsString(asArray[i], "Name", "Script");
			string asString2 = JSONUtils.GetAsString(asArray[i], "Head", ObjectType.WorkerHeadMk1.ToString());
			ObjectType identifierFromSaveName = ObjectTypeList.Instance.GetIdentifierFromSaveName(asString2, false);
			highInstructionList.Load(asArray[i]);
			AddScript(asString, highInstructionList, identifierFromSaveName);
		}
	}

	public void AddShout(string Phrase)
	{
		m_NewShouts.Add(new Shout(Phrase, 0));
		if (!m_RegisteredPhrases.ContainsKey(Phrase))
		{
			return;
		}
		foreach (RegisteredPhrase item in m_RegisteredPhrases[Phrase])
		{
			item.m_Triggered = true;
		}
	}

	private RegisteredPhrase GetInterpreterRegistered(string Phrase, WorkerInterpreter Interpreter)
	{
		if (m_RegisteredPhrases.ContainsKey(Phrase))
		{
			foreach (RegisteredPhrase item in m_RegisteredPhrases[Phrase])
			{
				if (item.m_Interpreter == Interpreter)
				{
					return item;
				}
			}
		}
		return null;
	}

	public bool GetCurrentShout(string Phrase, WorkerInterpreter Interpreter)
	{
		RegisteredPhrase interpreterRegistered = GetInterpreterRegistered(Phrase, Interpreter);
		if (interpreterRegistered != null && interpreterRegistered.m_Triggered)
		{
			List<RegisteredPhrase> list = m_RegisteredPhrases[Phrase];
			list.Remove(interpreterRegistered);
			if (list.Count == 0)
			{
				m_RegisteredPhrases.Remove(Phrase);
			}
			return true;
		}
		foreach (Shout currentShout in m_CurrentShouts)
		{
			if (currentShout.m_Phrase == Phrase)
			{
				return true;
			}
		}
		if (interpreterRegistered == null)
		{
			interpreterRegistered = new RegisteredPhrase(Interpreter);
			if (!m_RegisteredPhrases.ContainsKey(Phrase))
			{
				m_RegisteredPhrases.Add(Phrase, new List<RegisteredPhrase>());
			}
			m_RegisteredPhrases[Phrase].Add(interpreterRegistered);
		}
		return false;
	}

	private void Update()
	{
		foreach (Shout newShout in m_NewShouts)
		{
			m_CurrentShouts.Add(newShout);
		}
		m_NewShouts.Clear();
		for (int i = 0; i < m_CurrentShouts.Count; i++)
		{
			m_CurrentShouts[i].m_Frames++;
			if (m_CurrentShouts[i].m_Frames == 4)
			{
				m_CurrentShouts.RemoveAt(i);
				i--;
			}
		}
	}
}
