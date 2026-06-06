using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Name/Name List")]
public class NameList : ScriptableObject
{
	public string[] Names;

	[Header("Debug")]
	public TextAsset File;

	public int Index { get; private set; }

	public string ReturnRandomName()
	{
		return FlotsamGame.Random(Names);
	}

	[ContextMenu("Parse From File")]
	public void ParseFromFile()
	{
		if (File == null)
		{
			Debug.LogError("No file was passed in the debug parameter.");
			return;
		}
		Names = File.text.Split('\n');
		for (int i = 0; i < Names.Length; i++)
		{
			Names[i] = Names[i].Replace("\r", "");
		}
	}

	public void ResetIndex()
	{
		Index = 0;
	}

	public bool NextIndex()
	{
		Index++;
		if (Index < Names.Length)
		{
			return true;
		}
		Index = 0;
		return false;
	}

	public string ReturnNameAtIndex()
	{
		return Names[Index];
	}
}
