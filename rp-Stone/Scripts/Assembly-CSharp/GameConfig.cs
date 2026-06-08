using SafeTypes;
using UnityEngine;

public class GameConfig : MonoBehaviour
{
	public TextAsset configFile;

	public string salt;

	public SafeInt indexA;

	public SafeInt indexB;

	public SafeInt start;

	public SafeInt end;

	public static GameConfig singleton { get; private set; }

	public string GetSalt()
	{
		string text = "";
		int value = indexA.GetValue();
		int value2 = indexB.GetValue();
		int value3 = start.GetValue();
		int value4 = end.GetValue();
		for (int i = value3; i < value4; i++)
		{
			int num = 1 << i;
			if ((value & num) != 0)
			{
				text += salt[i];
			}
			if ((value2 & num) != 0)
			{
				text += salt[i];
			}
		}
		return text;
	}

	private void Awake()
	{
		string text = configFile.text;
		indexA = new SafeInt(SlimJson.ParseInt(text, "a"));
		indexB = new SafeInt(SlimJson.ParseInt(text, "b"));
		start = new SafeInt(SlimJson.ParseInt(text, "s"));
		end = new SafeInt(SlimJson.ParseInt(text, "e"));
		singleton = this;
	}
}
