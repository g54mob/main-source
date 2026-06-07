using System.IO;
using UnityEngine;

public class TestNewLevel : MonoBehaviour
{
	public new_level_info inf;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			Debug.Log(Application.dataPath);
			FileInfo fileInfo = new FileInfo(Application.dataPath + "/test.a2b");
			StreamWriter streamWriter;
			if (!fileInfo.Exists)
			{
				streamWriter = fileInfo.CreateText();
			}
			else
			{
				fileInfo.Delete();
				streamWriter = fileInfo.CreateText();
			}
			streamWriter.Write(JsonUtility.ToJson(inf));
			streamWriter.Close();
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			string path = Application.dataPath + "/test.a2b";
			if (File.Exists(path))
			{
				StreamReader streamReader = File.OpenText(path);
				string json = streamReader.ReadToEnd();
				inf = JsonUtility.FromJson<new_level_info>(json);
				streamReader.Close();
			}
		}
	}
}
