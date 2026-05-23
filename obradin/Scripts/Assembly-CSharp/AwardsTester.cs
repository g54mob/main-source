using System.IO;
using UnityEngine;

public class AwardsTester : MonoBehaviour
{
	private float clearTime;

	private string filename
	{
		get
		{
			return Path.Combine(Application.dataPath, "clear_awards.txt");
		}
	}

	private bool wantClear
	{
		get
		{
			return File.Exists(filename);
		}
	}

	private void Start()
	{
		clearTime = 0f;
		if (wantClear)
		{
			Debug.Log("Will delete awards: " + filename);
			clearTime = Time.realtimeSinceStartup + 2f;
			Awards.PrepForClearAll();
		}
		else
		{
			base.enabled = false;
		}
	}

	private void Update()
	{
		if (clearTime > 0f && Time.realtimeSinceStartup > clearTime)
		{
			clearTime = 0f;
			base.enabled = false;
			if (wantClear)
			{
				Awards.ClearAll();
			}
		}
	}
}
